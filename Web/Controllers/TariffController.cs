using Application.Commands.TariffCommands.Create;
using Application.Commands.TariffCommands.Delete;
using Application.Commands.TariffCommands.Update;
using Application.Common.Mappers;
using Application.Common.OrderStates;
using Application.Common.Responses;
using Application.Queries.TariffQueries.GetAll;
using Application.Queries.TariffQueries.GetById;
using Application.Queries.TariffTypeQueries.GetAll;
using Application.ViewModels;
using Application.ViewModels.IndexViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Controllers.Base;

namespace Web.Controllers;

[Authorize(Roles = "Admin, User")]
public class TariffController : BaseController
{
    public TariffController() : base(nameof(TariffController))
    {
    }

    public async Task<IActionResult> Index(string? filter, int? page, int? pageSize,
        TariffOrderState? orderState, bool resetFilter = false)
    {
        var query = new GetTariffsQuery();

        var response = await Mediator.Send(query);

        if (response.StatusCode == Status.BadRequest)
            return BadRequest(response.Description);

        var tariffs = response.Data.Select(x => x.ToIndexViewModel());

        if (resetFilter)
            HttpContext.Session.Remove(_constraints.INDEX_TEXT_FILTER_KEY);

        filter ??= GetFilterFromSessionOrSetDefaultValue();
        page ??= GetCurrentPageFromSessionOrSetDefaultValue();
        pageSize ??= GetPageSizeFromSessionOrSetDefaultValue();
        orderState ??= GetOrderStateFromSessionOrSetDefaultValue<TariffOrderState>();

        ViewData["Filter"] = filter;

        if (!string.IsNullOrEmpty(filter))
            tariffs = tariffs.Where(x => x.IsContainFilter(filter)).ToList();

        ChangeOrderState((TariffOrderState)orderState);

        tariffs = Order((TariffOrderState)orderState, tariffs);

        RewriteValuesInSession((string)filter, (int)page, (int)pageSize, (TariffOrderState)orderState);

        var pageViewModel = new PageViewModel(tariffs.Count(), (int)page, (int)pageSize);

        var indexViewModel = new IndexViewModel<IndexTariffViewModel>(tariffs, pageViewModel);

        return View(indexViewModel);
    }

    #region private methods for Index action
    private void ChangeOrderState(TariffOrderState orderState)
    {
        ViewData["IdSort"] = orderState == TariffOrderState.IdAsc ?
                    TariffOrderState.IdDesc : TariffOrderState.IdAsc;

        ViewData["NameSort"] = orderState == TariffOrderState.NameAsc ?
            TariffOrderState.NameDesc : TariffOrderState.NameAsc;

        ViewData["CostSort"] = orderState == TariffOrderState.CostAsc ?
            TariffOrderState.CostDesc : TariffOrderState.CostAsc;

        ViewData["MbCostSort"] = orderState == TariffOrderState.MbCostAsc ?
            TariffOrderState.MbCostDesc : TariffOrderState.MbCostAsc;
    }

    private static IEnumerable<IndexTariffViewModel> Order(TariffOrderState orderState,
        IEnumerable<IndexTariffViewModel> tariffs)
    {
        tariffs = orderState switch
        {
            TariffOrderState.IdAsc => tariffs.OrderBy(x => x.Id),
            TariffOrderState.IdDesc => tariffs.OrderByDescending(x => x.Id),
            TariffOrderState.NameAsc => tariffs.OrderBy(x => x.Name),
            TariffOrderState.NameDesc => tariffs.OrderByDescending(x => x.Name),
            TariffOrderState.CostAsc => tariffs.OrderBy(x => x.Cost),
            TariffOrderState.CostDesc => tariffs.OrderByDescending(x => x.Cost),
            TariffOrderState.MbCostAsc => tariffs.OrderBy(x => x.MbCost),
            TariffOrderState.MbCostDesc => tariffs.OrderByDescending(x => x.MbCost),
            _ => tariffs.OrderBy(x => x.Id)
        };
        return tariffs;
    }
    #endregion

    [Authorize(Roles = "Admin")]
    [ResponseCache(Duration = 300)]
    public async Task<IActionResult> Create()
    {
        var tariffTypes = await Mediator.Send(new GetTariffTypesQuery());

        if (tariffTypes.StatusCode != Status.BadRequest)
            ViewData["TariffTypes"] = new SelectList(tariffTypes.Data.OrderBy(x => x.Name), "Id", "Name");

        return View();
    }

    [HttpPost, ActionName("Create")]
    public async Task<IActionResult> CreatePost(CreateTariffCommand vm)
    {
        if (ModelState.IsValid)
        {
            await Mediator.Send(vm);

            return RedirectToAction("Index");
        }

        return View(vm);
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetTariffByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
               View(response.Data) : NotFound();
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetTariffByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
               View(response.Data) : NotFound();
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var command = new DeleteTariffCommand((Guid)id);

        var response = await Mediator.Send(command);

        return response.StatusCode == Status.Deleted ?
            RedirectToAction("Index") : BadRequest("Something went wrong");
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetTariffByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        if (response.StatusCode != Status.Ok)
            return NotFound();

        var tariffTypes = await Mediator.Send(new GetTariffTypesQuery());

        if (tariffTypes.StatusCode != Status.BadRequest)
            ViewData["TariffTypes"] = new SelectList(tariffTypes.Data.OrderBy(x => x.Name), "Id", "Name");

        return View(response.Data.ToUpdateViewModel());
    }

    [HttpPost, ActionName("Edit")]
    public async Task<IActionResult> EditPost(UpdateTariffCommand vm)
    {
        if (ModelState.IsValid)
        {
            await Mediator.Send(vm);

            return RedirectToAction("Index");
        }

        return View(vm);
    }
}
