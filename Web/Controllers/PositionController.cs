using Application.Commands.PositionCommands.Create;
using Application.Commands.PositionCommands.Delete;
using Application.Commands.PositionCommands.Update;
using Application.Common.Mappers;
using Application.Common.OrderStates;
using Application.Common.Responses;
using Application.Queries.PositionQueries.GetAll;
using Application.Queries.PositionQueries.GetById;
using Application.ViewModels;
using Application.ViewModels.IndexViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers;

[Authorize(Roles = "Admin,User")]
public class PositionController : BaseController
{
    public PositionController() : base(nameof(PositionController))
    {
    }

    public async Task<IActionResult> Index(string? filter, int? page, int? pageSize,
        PositionOrderState? orderState, bool resetFilter = false)
    {
        var query = new GetPositionsQuery();

        var response = await Mediator.Send(query);

        if (response.StatusCode == Status.BadRequest)
            return BadRequest(response.Description);

        var positions = response.Data.Select(x => x.ToIndexViewModel());

        if (resetFilter)
            HttpContext.Session.Remove(_constraints.INDEX_TEXT_FILTER_KEY);

        filter ??= GetFilterFromSessionOrSetDefaultValue();
        page ??= GetCurrentPageFromSessionOrSetDefaultValue();
        pageSize ??= GetPageSizeFromSessionOrSetDefaultValue();
        orderState ??= GetOrderStateFromSessionOrSetDefaultValue<PositionOrderState>();

        ViewData["Filter"] = filter;

        if (!string.IsNullOrEmpty(filter))
            positions = positions.Where(x => x.IsContainFilter(filter)).ToList();

        ChangeOrderState((PositionOrderState)orderState);

        positions = Order((PositionOrderState)orderState, positions);

        RewriteValuesInSession((string)filter, (int)page, (int)pageSize, (PositionOrderState)orderState);

        var pageViewModel = new PageViewModel(positions.Count(), (int)page, (int)pageSize);

        var indexViewModel = new IndexViewModel<IndexPositionViewModel>(positions, pageViewModel);

        return View(indexViewModel);
    }

    #region private methods for Index action
    private void ChangeOrderState(PositionOrderState orderState)
    {
        ViewData["IdSort"] = orderState == PositionOrderState.IdAsc ?
            PositionOrderState.IdDesc : PositionOrderState.IdAsc;

        ViewData["NameSort"] = orderState == PositionOrderState.NameAsc ?
            PositionOrderState.NameDesc : PositionOrderState.NameAsc;

        ViewData["SalarySort"] = orderState == PositionOrderState.SalaryAsc ?
            PositionOrderState.SalaryDesc : PositionOrderState.SalaryAsc;
    }

    private static IEnumerable<IndexPositionViewModel> Order(PositionOrderState orderState,
        IEnumerable<IndexPositionViewModel> positions)
    {
        positions = orderState switch
        {
            PositionOrderState.IdAsc => positions.OrderBy(x => x.Id),
            PositionOrderState.IdDesc => positions.OrderByDescending(x => x.Id),
            PositionOrderState.NameAsc => positions.OrderBy(x => x.Name),
            PositionOrderState.NameDesc => positions.OrderByDescending(x => x.Name),
            PositionOrderState.SalaryAsc => positions.OrderBy(x => x.Salary),
            PositionOrderState.SalaryDesc => positions.OrderByDescending(x => x.Salary),
            _ => positions.OrderBy(x => x.Id)
        };
        return positions;
    }
    #endregion

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetPositionByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        if (response.StatusCode == Status.NotFound)
            return NotFound(response.Description);

        var viewModel = response.Data.ToUpdateViewModel();

        return View(viewModel);
    }

    [HttpPost, ActionName("Edit")]
    public async Task<IActionResult> EditPost(UpdatePositionCommand vm)
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
    public async Task<IActionResult> CreatePost(CreatePositionCommand vm)
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

        var query = new GetPositionByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
            View(response.Data) : BadRequest(response.Description);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var command = new DeletePositionCommand((Guid)id);

        var response = await Mediator.Send(command);

        return response.StatusCode == Status.Deleted ?
            RedirectToAction("Index") : BadRequest(response.Description);
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetPositionByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
            View(response.Data) : BadRequest(response.Description);
    }
}
