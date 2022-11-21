using Application.Commands.InternetTrafficCommands.Create;
using Application.Commands.InternetTrafficCommands.Delete;
using Application.Commands.InternetTrafficCommands.Update;
using Application.Common.Mappers;
using Application.Common.OrderStates;
using Application.Common.Responses;
using Application.Queries.ContractQueries.GetAll;
using Application.Queries.InternetTrafficQueries.GetAll;
using Application.Queries.InternetTrafficQueries.GetById;
using Application.ViewModels;
using Application.ViewModels.IndexViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Controllers.Base;

namespace Web.Controllers;

[Authorize(Roles = "Admin, User")]
public class InternetTrafficController : BaseController
{
    public InternetTrafficController() : base(nameof(InternetTrafficController))
    {
    }

    public async Task<IActionResult> Index(string? filter, int? page, int? pageSize,
        InternetTrafficOrderState? orderState, bool resetFilter = false)
    {
        var query = new GetInternetTrafficsQuery();

        var response = await Mediator.Send(query);

        if (response.StatusCode == Status.BadRequest)
            return BadRequest(response.Description);

        var internetTraffics = response.Data.Select(x => x.ToIndexViewModel());

        if (resetFilter)
            HttpContext.Session.Remove(_constraints.INDEX_TEXT_FILTER_KEY);

        filter ??= GetFilterFromSessionOrSetDefaultValue();
        page ??= GetCurrentPageFromSessionOrSetDefaultValue();
        pageSize ??= GetPageSizeFromSessionOrSetDefaultValue();
        orderState ??= GetOrderStateFromSessionOrSetDefaultValue<InternetTrafficOrderState>();

        ViewData["Filter"] = filter;

        if (!string.IsNullOrEmpty(filter))
            internetTraffics = internetTraffics.Where(x => x.IsContainFilter(filter)).ToList();

        ChangeOrderState((InternetTrafficOrderState)orderState);

        internetTraffics = Order((InternetTrafficOrderState)orderState, internetTraffics);

        RewriteValuesInSession((string)filter, (int)page, (int)pageSize, (InternetTrafficOrderState)orderState);

        var pageViewModel = new PageViewModel(internetTraffics.Count(), (int)page, (int)pageSize);

        var indexViewModel = new IndexViewModel<IndexInternetTrafficViewModel>(internetTraffics, pageViewModel);

        return View(indexViewModel);
    }

    #region private methods for Index action
    private void ChangeOrderState(InternetTrafficOrderState orderState)
    {
        ViewData["IdSort"] = orderState == InternetTrafficOrderState.IdAsc ?
                    InternetTrafficOrderState.IdDesc : InternetTrafficOrderState.IdAsc;

        ViewData["MbSpentSort"] = orderState == InternetTrafficOrderState.MbSpentAsc ?
            InternetTrafficOrderState.MbSpentDesc : InternetTrafficOrderState.MbSpentAsc;

        ViewData["DateSort"] = orderState == InternetTrafficOrderState.DateAsc ?
            InternetTrafficOrderState.DateDesc : InternetTrafficOrderState.DateAsc;

        ViewData["PhoneNumberSort"] = orderState == InternetTrafficOrderState.PhoneNumberAsc ?
            InternetTrafficOrderState.PhoneNumberDesc : InternetTrafficOrderState.PhoneNumberAsc;
    }

    private static IEnumerable<IndexInternetTrafficViewModel> Order(InternetTrafficOrderState orderState,
        IEnumerable<IndexInternetTrafficViewModel> internetTraffics)
    {
        internetTraffics = orderState switch
        {
            InternetTrafficOrderState.IdAsc => internetTraffics.OrderBy(x => x.Id),
            InternetTrafficOrderState.IdDesc => internetTraffics.OrderByDescending(x => x.Id),
            InternetTrafficOrderState.DateAsc => internetTraffics.OrderBy(x => x.Date),
            InternetTrafficOrderState.DateDesc => internetTraffics.OrderByDescending(x => x.Date),
            InternetTrafficOrderState.MbSpentAsc => internetTraffics.OrderBy(x => x.MbSpent),
            InternetTrafficOrderState.MbSpentDesc => internetTraffics.OrderByDescending(x => x.MbSpent),
            InternetTrafficOrderState.PhoneNumberAsc => internetTraffics.OrderBy(x => x.PhoneNumber),
            InternetTrafficOrderState.PhoneNumberDesc => internetTraffics.OrderByDescending(x => x.PhoneNumber),
            _ => internetTraffics.OrderBy(x => x.Id)
        };
        return internetTraffics;
    }
    #endregion

    [Authorize(Roles = "Admin")]
    [ResponseCache(Duration = 300)]
    public async Task<IActionResult> Create()
    {
        var contracts = await Mediator.Send(new GetContractsQuery());

        if (contracts.StatusCode != Status.BadRequest)
            ViewData["Contracts"] = new SelectList(contracts.Data.OrderBy(x => x.PhoneNumber), "Id", "PhoneNumber");

        return View();
    }

    [HttpPost, ActionName("Create")]
    public async Task<IActionResult> CreatePost(CreateInternetTrafficCommand vm)
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

        var query = new GetInternetTrafficByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
               View(response.Data) : NotFound();
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetInternetTrafficByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
               View(response.Data) : NotFound();
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var command = new DeleteInternetTrafficCommand((Guid)id);

        var response = await Mediator.Send(command);

        return response.StatusCode == Status.Deleted ?
            RedirectToAction("Index") : BadRequest("Something went wrong");
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetInternetTrafficByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        if (response.StatusCode != Status.Ok)
            return NotFound();

        var contracts = await Mediator.Send(new GetContractsQuery());

        if (contracts.StatusCode != Status.BadRequest)
            ViewData["Contracts"] = new SelectList(contracts.Data.OrderBy(x => x.PhoneNumber), "Id", "PhoneNumber");

        return View(response.Data.ToUpdateViewModel());
    }

    [HttpPost, ActionName("Edit")]
    public async Task<IActionResult> EditPost(UpdateInternetTrafficCommand vm)
    {
        if (ModelState.IsValid)
        {
            await Mediator.Send(vm);

            return RedirectToAction("Index");
        }

        return View(vm);
    }
}
