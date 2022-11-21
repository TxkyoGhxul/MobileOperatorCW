using Application.Commands.EmployeeCommands.Create;
using Application.Commands.EmployeeCommands.Delete;
using Application.Commands.EmployeeCommands.Update;
using Application.Common.Mappers;
using Application.Common.OrderStates;
using Application.Common.Responses;
using Application.Queries.EmployeeQueries.GetAll;
using Application.Queries.EmployeeQueries.GetById;
using Application.Queries.PositionQueries.GetAll;
using Application.ViewModels;
using Application.ViewModels.IndexViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Controllers.Base;

namespace Web.Controllers;

[Authorize(Roles = "Admin, User")]
public class EmployeeController : BaseController
{
    public EmployeeController() : base(nameof(PositionController))
    {
    }

    public async Task<IActionResult> Index(string? filter, int? page, int? pageSize,
        EmployeesOrderState? orderState, bool resetFilter = false)
    {
        var query = new GetEmployeesQuery();

        var response = await Mediator.Send(query);

        if (response.StatusCode == Status.BadRequest)
            return BadRequest(response.Description);

        var employees = response.Data.Select(x => x.ToIndexViewModel());

        if (resetFilter)
            HttpContext.Session.Remove(_constraints.INDEX_TEXT_FILTER_KEY);

        filter ??= GetFilterFromSessionOrSetDefaultValue();
        page ??= GetCurrentPageFromSessionOrSetDefaultValue();
        pageSize ??= GetPageSizeFromSessionOrSetDefaultValue();
        orderState ??= GetOrderStateFromSessionOrSetDefaultValue<EmployeesOrderState>();

        ViewData["Filter"] = filter;

        if (!string.IsNullOrEmpty(filter))
            employees = employees.Where(x => x.IsContainFilter(filter)).ToList();

        ChangeOrderState((EmployeesOrderState)orderState);

        employees = Order((EmployeesOrderState)orderState, employees);

        RewriteValuesInSession((string)filter, (int)page, (int)pageSize, (EmployeesOrderState)orderState);

        var pageViewModel = new PageViewModel(employees.Count(), (int)page, (int)pageSize);

        var indexViewModel = new IndexViewModel<IndexEmployeeViewModel>(employees, pageViewModel);

        return View(indexViewModel);
    }

    #region private methods for Index action
    private void ChangeOrderState(EmployeesOrderState orderState)
    {
        ViewData["IdSort"] = orderState == EmployeesOrderState.IdAsc ?
            EmployeesOrderState.IdDesc : EmployeesOrderState.IdAsc;

        ViewData["NameSort"] = orderState == EmployeesOrderState.NameAsc ?
            EmployeesOrderState.NameDesc : EmployeesOrderState.NameAsc;

        ViewData["SurnameSort"] = orderState == EmployeesOrderState.SurnameAsc ?
            EmployeesOrderState.SurnameDesc : EmployeesOrderState.SurnameAsc;

        ViewData["MiddleNameSort"] = orderState == EmployeesOrderState.MiddleNameAsc ?
            EmployeesOrderState.MiddleNameDesc : EmployeesOrderState.MiddleNameAsc;

        ViewData["PositionSort"] = orderState == EmployeesOrderState.PositionAsc ?
            EmployeesOrderState.PositionDesc : EmployeesOrderState.PositionAsc;
    }

    private static IEnumerable<IndexEmployeeViewModel> Order(EmployeesOrderState orderState,
        IEnumerable<IndexEmployeeViewModel> employees)
    {
        employees = orderState switch
        {
            EmployeesOrderState.IdAsc => employees.OrderBy(x => x.Id),
            EmployeesOrderState.IdDesc => employees.OrderByDescending(x => x.Id),
            EmployeesOrderState.NameAsc => employees.OrderBy(x => x.Name),
            EmployeesOrderState.NameDesc => employees.OrderByDescending(x => x.Name),
            EmployeesOrderState.SurnameAsc => employees.OrderBy(x => x.Surname),
            EmployeesOrderState.SurnameDesc => employees.OrderByDescending(x => x.Surname),
            EmployeesOrderState.MiddleNameAsc => employees.OrderBy(x => x.MiddleName),
            EmployeesOrderState.MiddleNameDesc => employees.OrderByDescending(x => x.MiddleName),
            EmployeesOrderState.PositionAsc => employees.OrderBy(x => x.Position),
            EmployeesOrderState.PositionDesc => employees.OrderByDescending(x => x.Position),
            _ => employees.OrderBy(x => x.Id)
        };
        return employees;
    }
    #endregion

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetEmployeeByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        if (response.StatusCode == Status.NotFound)
            return NotFound(response.Description);

        var positionsQuery = new GetPositionsQuery();

        var positionsResponse = await Mediator.Send(positionsQuery);

        if (response.StatusCode == Status.NotFound)
            return NotFound(response.Description);

        ViewData["Positions"] = new SelectList(positionsResponse.Data.OrderBy(x => x.Name), "Id", "Name");

        var viewModel = response.Data.ToUpdateViewModel();

        return View(viewModel);
    }

    [HttpPost, ActionName("Edit")]
    public async Task<IActionResult> EditPost(UpdateEmployeeCommand vm)
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
        var query = new GetPositionsQuery();

        var response = await Mediator.Send(query);

        if (response.StatusCode == Status.NotFound)
            return NotFound(response.Description);

        ViewData["Positions"] = new SelectList(response.Data.OrderBy(x => x.Name), "Id", "Name");

        return View();
    }

    [HttpPost, ActionName("Create")]
    public async Task<IActionResult> CreatePost(CreateEmployeeCommand vm)
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

        var query = new GetEmployeeByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
            View(response.Data) : BadRequest(response.Description);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var command = new DeleteEmployeeCommand((Guid)id);

        var response = await Mediator.Send(command);

        return response.StatusCode == Status.Deleted ?
            RedirectToAction("Index") : BadRequest(response.Description);
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetEmployeeByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
            View(response.Data) : BadRequest(response.Description);
    }
}
