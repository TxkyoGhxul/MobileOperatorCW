using Application.Commands.UserCommands.CreateUser;
using Application.Commands.UserCommands.DeleteUser;
using Application.Commands.UserCommands.UpdateUser;
using Application.Common.Mappers;
using Application.Common.OrderStates;
using Application.Common.Responses;
using Application.Queries.UserQueries.GetAll;
using Application.Queries.UserQueries.GetById;
using Application.ViewModels;
using Application.ViewModels.IndexViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers;

[Authorize(Roles = "Admin, User")]
public class UserController : BaseController
{
    public UserController() : base(nameof(UserController))
    {
    }

    public async Task<IActionResult> Index(string? filter, int? page, int? pageSize,
        UserOrderState? orderState, bool resetFilter = false)
    {
        var query = new GetUsersQuery();

        var response = await Mediator.Send(query);

        if (response.StatusCode == Status.BadRequest)
            return BadRequest(response.Description);

        var users = response.Data.Select(x => x.ToIndexViewModel());

        if (resetFilter)
            HttpContext.Session.Remove(_constraints.INDEX_TEXT_FILTER_KEY);

        filter ??= GetFilterFromSessionOrSetDefaultValue();
        page ??= GetCurrentPageFromSessionOrSetDefaultValue();
        pageSize ??= GetPageSizeFromSessionOrSetDefaultValue();
        orderState ??= GetOrderStateFromSessionOrSetDefaultValue<UserOrderState>();

        ViewData["Filter"] = filter;

        if (!string.IsNullOrEmpty(filter))
            users = users.Where(x => x.IsContainFilter(filter)).ToList();

        ChangeOrderState((UserOrderState)orderState);

        users = Order((UserOrderState)orderState, users);

        RewriteValuesInSession((string)filter, (int)page, (int)pageSize, (UserOrderState)orderState);

        var pageViewModel = new PageViewModel(users.Count(), (int)page, (int)pageSize);

        var indexViewModel = new IndexViewModel<IndexUserViewModel>(users, pageViewModel);

        return View(indexViewModel);
    }

    #region private methods for Index action
    private void ChangeOrderState(UserOrderState orderState)
    {
        ViewData["IdSort"] = orderState == UserOrderState.IdAsc ?
            UserOrderState.IdDesc : UserOrderState.IdAsc;

        ViewData["NameSort"] = orderState == UserOrderState.NameAsc ?
            UserOrderState.NameDesc : UserOrderState.NameAsc;

        ViewData["SurnameSort"] = orderState == UserOrderState.SurnameAsc ?
            UserOrderState.SurnameDesc : UserOrderState.SurnameAsc;

        ViewData["MiddleNameSort"] = orderState == UserOrderState.MiddleNameAsc ?
            UserOrderState.MiddleNameDesc : UserOrderState.MiddleNameAsc;

        ViewData["PassportSort"] = orderState == UserOrderState.PassportAsc ?
            UserOrderState.PassportDesc : UserOrderState.PassportAsc;
    }

    private static IEnumerable<IndexUserViewModel> Order(UserOrderState orderState,
        IEnumerable<IndexUserViewModel> users)
    {
        users = orderState switch
        {
            UserOrderState.IdAsc => users.OrderBy(x => x.Id),
            UserOrderState.IdDesc => users.OrderByDescending(x => x.Id),
            UserOrderState.NameAsc => users.OrderBy(x => x.Name),
            UserOrderState.NameDesc => users.OrderByDescending(x => x.Name),
            UserOrderState.SurnameAsc => users.OrderBy(x => x.Surname),
            UserOrderState.SurnameDesc => users.OrderByDescending(x => x.Surname),
            UserOrderState.MiddleNameAsc => users.OrderBy(x => x.MiddleName),
            UserOrderState.MiddleNameDesc => users.OrderByDescending(x => x.MiddleName),
            UserOrderState.PassportAsc => users.OrderBy(x => x.Passport),
            UserOrderState.PassportDesc => users.OrderByDescending(x => x.Passport),
            _ => users.OrderBy(x => x.Id)
        };
        return users;
    }
    #endregion

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetUserByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.NotFound ?
            NotFound(response.Description) : View(response.Data.ToUpdateViewModel());
    }

    [HttpPost, ActionName("Edit")]
    public async Task<IActionResult> EditPost(UpdateUserCommand vm)
    {
        if (ModelState.IsValid)
        {
            var response = await Mediator.Send(vm);

            return response.StatusCode == Status.Updated ?
                RedirectToAction("Index") : BadRequest(response.Description);
        }

        return View(vm);
    }

    [Authorize(Roles = "Admin")]
    [ResponseCache(Duration = 300)]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost, ActionName("Create")]
    public async Task<IActionResult> CreatePost(CreateUserCommand vm)
    {
        if (ModelState.IsValid)
        {
            var response = await Mediator.Send(vm);

            return response.StatusCode == Status.Created ?
                RedirectToAction("Index") : BadRequest(response.Description);
        }

        return View(vm);
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetUserByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
            View(response.Data) : BadRequest(response.Description);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var command = new DeleteUserCommand((Guid)id);

        var response = await Mediator.Send(command);

        return response.StatusCode == Status.Deleted ?
            RedirectToAction("Index") : BadRequest(response.Description);
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetUserByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
            View(response.Data) : BadRequest(response.Description);
    }
}
