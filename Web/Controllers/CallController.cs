using Application.Commands.CallCommands.CreateCall;
using Application.Commands.CallCommands.DeleteCall;
using Application.Commands.CallCommands.UpdateCall;
using Application.Common.Mappers;
using Application.Common.OrderStates;
using Application.Common.Responses;
using Application.Queries.CallQueries.GetAll;
using Application.Queries.CallQueries.GetById;
using Application.Queries.ContractQueries.GetAll;
using Application.ViewModels;
using Application.ViewModels.IndexViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Controllers.Base;

namespace Web.Controllers;

[Authorize(Roles = "Admin, User")]
public class CallController : BaseController
{
    public CallController() : base(nameof(ContractController))
    {
    }

    public async Task<IActionResult> Index(string? filter, int? page, int? pageSize,
        CallOrderState? orderState, bool resetFilter = false)
    {
        var query = new GetCallsQuery();

        var response = await Mediator.Send(query);

        if (response.StatusCode == Status.BadRequest)
            return BadRequest(response.Description);

        var calls = response.Data.Select(x => x.ToIndexViewModel());

        if (resetFilter)
            HttpContext.Session.Remove(_constraints.INDEX_TEXT_FILTER_KEY);

        filter ??= GetFilterFromSessionOrSetDefaultValue();
        page ??= GetCurrentPageFromSessionOrSetDefaultValue();
        pageSize ??= GetPageSizeFromSessionOrSetDefaultValue();
        orderState ??= GetOrderStateFromSessionOrSetDefaultValue<CallOrderState>();

        ViewData["Filter"] = filter;

        if (!string.IsNullOrEmpty(filter))
            calls = calls.Where(x => x.IsContainFilter(filter)).ToList();

        ChangeOrderState((CallOrderState)orderState);

        calls = Order((CallOrderState)orderState, calls);

        RewriteValuesInSession((string)filter, (int)page, (int)pageSize, (CallOrderState)orderState);

        var pageViewModel = new PageViewModel(calls.Count(), (int)page, (int)pageSize);

        var indexViewModel = new IndexViewModel<IndexCallViewModel>(calls, pageViewModel);

        return View(indexViewModel);
    }

    #region private methods for Index action
    private void ChangeOrderState(CallOrderState orderState)
    {
        ViewData["IdSort"] = orderState == CallOrderState.IdAsc ?
                    CallOrderState.IdDesc : CallOrderState.IdAsc;

        ViewData["TimeSpanSort"] = orderState == CallOrderState.TimeSpanAsc ?
            CallOrderState.TimeSpanDesc : CallOrderState.TimeSpanAsc;

        ViewData["DateSort"] = orderState == CallOrderState.DateAsc ?
            CallOrderState.DateDesc : CallOrderState.DateAsc;

        ViewData["PhoneNumberSort"] = orderState == CallOrderState.PhoneNumberAsc ?
            CallOrderState.PhoneNumberDesc : CallOrderState.PhoneNumberAsc;
    }

    private static IEnumerable<IndexCallViewModel> Order(CallOrderState orderState,
        IEnumerable<IndexCallViewModel> calls)
    {
        calls = orderState switch
        {
            CallOrderState.IdAsc => calls.OrderBy(x => x.Id),
            CallOrderState.IdDesc => calls.OrderByDescending(x => x.Id),
            CallOrderState.DateAsc => calls.OrderBy(x => x.Date),
            CallOrderState.DateDesc => calls.OrderByDescending(x => x.Date),
            CallOrderState.TimeSpanAsc => calls.OrderBy(x => x.TimeSpan),
            CallOrderState.TimeSpanDesc => calls.OrderByDescending(x => x.TimeSpan),
            CallOrderState.PhoneNumberAsc => calls.OrderBy(x => x.PhoneNumber),
            CallOrderState.PhoneNumberDesc => calls.OrderByDescending(x => x.PhoneNumber),
            _ => calls.OrderBy(x => x.Id)
        };
        return calls;
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
    public async Task<IActionResult> CreatePost(CreateCallCommand vm)
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

        var query = new GetCallByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
               View(response.Data) : NotFound();
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetCallByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
               View(response.Data) : NotFound();
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var command = new DeleteCallCommand((Guid)id);

        var response = await Mediator.Send(command);

        return response.StatusCode == Status.Deleted ?
            RedirectToAction("Index") : BadRequest("Something went wrong");
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetCallByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        if (response.StatusCode != Status.Ok)
            return NotFound();

        var contracts = await Mediator.Send(new GetContractsQuery());

        if (contracts.StatusCode != Status.BadRequest)
            ViewData["Contracts"] = new SelectList(contracts.Data.OrderBy(x => x.PhoneNumber), "Id", "PhoneNumber");

        return View(response.Data.ToUpdateViewModel());
    }

    [HttpPost, ActionName("Edit")]
    public async Task<IActionResult> EditPost(UpdateCallCommand vm)
    {
        if (ModelState.IsValid)
        {
            await Mediator.Send(vm);

            return RedirectToAction("Index");
        }

        return View(vm);
    }
}
