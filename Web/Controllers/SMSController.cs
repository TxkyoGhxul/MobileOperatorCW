using Application.Commands.SMSCommands.Create;
using Application.Commands.SMSCommands.Delete;
using Application.Commands.SMSCommands.Update;
using Application.Common.Mappers;
using Application.Common.OrderStates;
using Application.Common.Responses;
using Application.Queries.ContractQueries.GetAll;
using Application.Queries.SMSQueries.GetAll;
using Application.Queries.SMSQueries.GetById;
using Application.ViewModels;
using Application.ViewModels.IndexViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Controllers.Base;

namespace Web.Controllers;
public class SMSController : BaseController
{
    public SMSController() : base(nameof(SMSController))
    {
    }

    public async Task<IActionResult> Index(string? filter, int? page, int? pageSize,
        SMSOrderState? orderState, bool resetFilter = false)
    {
        var query = new GetSMSsQuery();

        var response = await Mediator.Send(query);

        if (response.StatusCode == Status.BadRequest)
            return BadRequest(response.Description);

        var smss = response.Data.Select(x => x.ToIndexViewModel());

        if (resetFilter)
            HttpContext.Session.Remove(_constraints.INDEX_TEXT_FILTER_KEY);

        filter ??= GetFilterFromSessionOrSetDefaultValue();
        page ??= GetCurrentPageFromSessionOrSetDefaultValue();
        pageSize ??= GetPageSizeFromSessionOrSetDefaultValue();
        orderState ??= GetOrderStateFromSessionOrSetDefaultValue<SMSOrderState>();

        ViewData["Filter"] = filter;

        if (!string.IsNullOrEmpty(filter))
            smss = smss.Where(x => x.IsContainFilter(filter)).ToList();

        ChangeOrderState((SMSOrderState)orderState);

        smss = Order((SMSOrderState)orderState, smss);

        RewriteValuesInSession((string)filter, (int)page, (int)pageSize, (SMSOrderState)orderState);

        var pageViewModel = new PageViewModel(smss.Count(), (int)page, (int)pageSize);

        var indexViewModel = new IndexViewModel<IndexSMSViewModel>(smss, pageViewModel);

        return View(indexViewModel);
    }

    #region private methods for Index action
    private void ChangeOrderState(SMSOrderState orderState)
    {
        ViewData["IdSort"] = orderState == SMSOrderState.IdAsc ?
                    SMSOrderState.IdDesc : SMSOrderState.IdAsc;

        ViewData["MessageSort"] = orderState == SMSOrderState.MessageAsc ?
            SMSOrderState.MessageDesc : SMSOrderState.MessageAsc;

        ViewData["DateSort"] = orderState == SMSOrderState.DateAsc ?
            SMSOrderState.DateDesc : SMSOrderState.DateAsc;

        ViewData["PhoneNumberSort"] = orderState == SMSOrderState.PhoneNumberAsc ?
            SMSOrderState.PhoneNumberDesc : SMSOrderState.PhoneNumberAsc;
    }

    private static IEnumerable<IndexSMSViewModel> Order(SMSOrderState orderState,
        IEnumerable<IndexSMSViewModel> smss)
    {
        smss = orderState switch
        {
            SMSOrderState.IdAsc => smss.OrderBy(x => x.Id),
            SMSOrderState.IdDesc => smss.OrderByDescending(x => x.Id),
            SMSOrderState.DateAsc => smss.OrderBy(x => x.Date),
            SMSOrderState.DateDesc => smss.OrderByDescending(x => x.Date),
            SMSOrderState.MessageAsc => smss.OrderBy(x => x.Message),
            SMSOrderState.MessageDesc => smss.OrderByDescending(x => x.Message),
            SMSOrderState.PhoneNumberAsc => smss.OrderBy(x => x.PhoneNumber),
            SMSOrderState.PhoneNumberDesc => smss.OrderByDescending(x => x.PhoneNumber),
            _ => smss.OrderBy(x => x.Id)
        };
        return smss;
    }
    #endregion

    [ResponseCache(Duration = 300)]
    public async Task<IActionResult> Create()
    {
        var contracts = await Mediator.Send(new GetContractsQuery());

        if (contracts.StatusCode != Status.BadRequest)
            ViewData["Contracts"] = new SelectList(contracts.Data.OrderBy(x => x.PhoneNumber), "Id", "PhoneNumber");

        return View();
    }

    [HttpPost, ActionName("Create")]
    public async Task<IActionResult> CreatePost(CreateSMSCommand vm)
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

        var query = new GetSMSByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
               View(response.Data) : NotFound();
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetSMSByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
               View(response.Data) : NotFound();
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var command = new DeleteSMSCommand((Guid)id);

        var response = await Mediator.Send(command);

        return response.StatusCode == Status.Deleted ?
            RedirectToAction("Index") : BadRequest("Something went wrong");
    }

    public async Task<IActionResult> Edit(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetSMSByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        if (response.StatusCode != Status.Ok)
            return NotFound();

        var contracts = await Mediator.Send(new GetContractsQuery());

        if (contracts.StatusCode != Status.BadRequest)
            ViewData["Contracts"] = new SelectList(contracts.Data.OrderBy(x => x.PhoneNumber), "Id", "PhoneNumber");

        return View(response.Data.ToUpdateViewModel());
    }

    [HttpPost, ActionName("Edit")]
    public async Task<IActionResult> EditPost(UpdateSMSCommand vm)
    {
        if (ModelState.IsValid)
        {
            await Mediator.Send(vm);

            return RedirectToAction("Index");
        }

        return View(vm);
    }
}
