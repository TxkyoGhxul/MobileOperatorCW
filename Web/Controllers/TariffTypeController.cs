using Application.Commands.TariffTypeCommands.Create;
using Application.Commands.TariffTypeCommands.Delete;
using Application.Commands.TariffTypeCommands.Update;
using Application.Common.Mappers;
using Application.Common.OrderStates;
using Application.Common.Responses;
using Application.Queries.TariffQueries.GetById;
using Application.Queries.TariffTypeQueries.GetAll;
using Application.Queries.TariffTypeQueries.GetById;
using Application.ViewModels;
using Application.ViewModels.IndexViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers;

[Authorize(Roles = "Admin, User")]
public class TariffTypeController : BaseController
{
    public TariffTypeController() : base(nameof(TariffTypeController))
    {
    }

    public async Task<IActionResult> Index(string? filter, int? page, int? pageSize,
        TariffTypeOrderState? orderState, bool resetFilter = false)
    {
        var query = new GetTariffTypesQuery();

        var response = await Mediator.Send(query);

        if (response.StatusCode == Status.BadRequest)
            return BadRequest(response.Description);

        var tariffTypes = response.Data.Select(x => x.ToIndexViewModel());

        if (resetFilter)
            HttpContext.Session.Remove(_constraints.INDEX_TEXT_FILTER_KEY);

        filter ??= GetFilterFromSessionOrSetDefaultValue();
        page ??= GetCurrentPageFromSessionOrSetDefaultValue();
        pageSize ??= GetPageSizeFromSessionOrSetDefaultValue();
        orderState ??= GetOrderStateFromSessionOrSetDefaultValue<TariffTypeOrderState>();

        ViewData["Filter"] = filter;

        if (!string.IsNullOrEmpty(filter))
            tariffTypes = tariffTypes.Where(x => x.IsContainFilter(filter)).ToList();

        ChangeOrderState((TariffTypeOrderState)orderState);

        tariffTypes = Order((TariffTypeOrderState)orderState, tariffTypes);

        RewriteValuesInSession((string)filter, (int)page, (int)pageSize, (TariffTypeOrderState)orderState);

        var pageViewModel = new PageViewModel(tariffTypes.Count(), (int)page, (int)pageSize);

        var indexViewModel = new IndexViewModel<IndexTariffTypeViewModel>(tariffTypes, pageViewModel);

        return View(indexViewModel);
    }

    #region private methods for Index action
    private void ChangeOrderState(TariffTypeOrderState orderState)
    {
        ViewData["IdSort"] = orderState == TariffTypeOrderState.IdAsc ?
                    TariffTypeOrderState.IdDesc : TariffTypeOrderState.IdAsc;

        ViewData["NameSort"] = orderState == TariffTypeOrderState.NameAsc ?
            TariffTypeOrderState.NameDesc : TariffTypeOrderState.NameAsc;
    }

    private static IEnumerable<IndexTariffTypeViewModel> Order(TariffTypeOrderState orderState,
        IEnumerable<IndexTariffTypeViewModel> tariffTypes)
    {
        tariffTypes = orderState switch
        {
            TariffTypeOrderState.IdAsc => tariffTypes.OrderBy(x => x.Id),
            TariffTypeOrderState.IdDesc => tariffTypes.OrderByDescending(x => x.Id),
            TariffTypeOrderState.NameAsc => tariffTypes.OrderBy(x => x.Name),
            TariffTypeOrderState.NameDesc => tariffTypes.OrderByDescending(x => x.Name),
            _ => tariffTypes.OrderBy(x => x.Id)
        };
        return tariffTypes;
    }
    #endregion

    [Authorize(Roles = "Admin")]
    [ResponseCache(Duration = 300)]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost, ActionName("Create")]
    public async Task<IActionResult> CreatePost(CreateTariffTypeCommand vm)
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

        var query = new GetTariffTypeByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
               View(response.Data) : NotFound();
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetTariffTypeByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
               View(response.Data) : NotFound();
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var command = new DeleteTariffTypeCommand((Guid)id);

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

        return View(response.Data.ToUpdateViewModel());
    }

    [HttpPost, ActionName("Edit")]
    public async Task<IActionResult> EditPost(UpdateTariffTypeCommand vm)
    {
        if (ModelState.IsValid)
        {
            await Mediator.Send(vm);

            return RedirectToAction("Index");
        }

        return View(vm);
    }
}
