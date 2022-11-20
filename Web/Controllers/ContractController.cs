using Application.Commands.ContractCommands.Create;
using Application.Commands.ContractCommands.Delete;
using Application.Commands.ContractCommands.Update;
using Application.Common.Mappers;
using Application.Common.OrderStates;
using Application.Common.Responses;
using Application.Queries.ContractQueries.GetAll;
using Application.Queries.ContractQueries.GetById;
using Application.Queries.EmployeeQueries.GetAll;
using Application.Queries.TariffQueries.GetAll;
using Application.Queries.UserQueries.GetAll;
using Application.ViewModels;
using Application.ViewModels.IndexViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Controllers.Base;

namespace Web.Controllers;
public class ContractController : BaseController
{
    public ContractController() : base(nameof(ContractController))
    {
    }

    public async Task<IActionResult> Index(string? filter, int? page, int? pageSize,
        ContractOrderState? orderState, bool resetFilter = false)
    {
        var query = new GetContractsQuery();

        var response = await Mediator.Send(query);

        if (response.StatusCode == Status.BadRequest)
            return BadRequest(response.Description);

        var contracts = response.Data.Select(x => x.ToIndexViewModel());

        if (resetFilter)
            HttpContext.Session.Remove(_constraints.INDEX_TEXT_FILTER_KEY);

        filter ??= GetFilterFromSessionOrSetDefaultValue();
        page ??= GetCurrentPageFromSessionOrSetDefaultValue();
        pageSize ??= GetPageSizeFromSessionOrSetDefaultValue();
        orderState ??= GetOrderStateFromSessionOrSetDefaultValue<ContractOrderState>();

        ViewData["Filter"] = filter;

        if (!string.IsNullOrEmpty(filter))
            contracts = contracts.Where(x => x.IsContainFilter(filter)).ToList();

        ChangeOrderState((ContractOrderState)orderState);

        contracts = Order((ContractOrderState)orderState, contracts);

        RewriteValuesInSession((string)filter, (int)page, (int)pageSize, (ContractOrderState)orderState);

        var pageViewModel = new PageViewModel(contracts.Count(), (int)page, (int)pageSize);

        var indexViewModel = new IndexViewModel<IndexContractViewModel>(contracts, pageViewModel);

        return View(indexViewModel);
    }

    #region private methods for Index action
    private void ChangeOrderState(ContractOrderState orderState)
    {
        ViewData["IdSort"] = orderState == ContractOrderState.IdAsc ?
                    ContractOrderState.IdDesc : ContractOrderState.IdAsc;

        ViewData["TariffSort"] = orderState == ContractOrderState.TariffAsc ?
            ContractOrderState.TariffDesc : ContractOrderState.TariffAsc;

        ViewData["DateSort"] = orderState == ContractOrderState.DateAsc ?
            ContractOrderState.DateDesc : ContractOrderState.DateAsc;

        ViewData["EmployeeSurnameSort"] = orderState == ContractOrderState.EmployeeSurnameAsc ?
            ContractOrderState.EmployeeSurnameDesc : ContractOrderState.EmployeeSurnameAsc;

        ViewData["UserSurnameSort"] = orderState == ContractOrderState.UserSurnameAsc ?
            ContractOrderState.UserSurnameDesc : ContractOrderState.UserSurnameAsc;

        ViewData["PhoneNumberSort"] = orderState == ContractOrderState.PhoneNumberAsc ?
            ContractOrderState.PhoneNumberDesc : ContractOrderState.PhoneNumberAsc;
    }

    private static IEnumerable<IndexContractViewModel> Order(ContractOrderState orderState,
        IEnumerable<IndexContractViewModel> contracts)
    {
        contracts = orderState switch
        {
            ContractOrderState.IdAsc => contracts.OrderBy(x => x.Id),
            ContractOrderState.IdDesc => contracts.OrderByDescending(x => x.Id),
            ContractOrderState.DateAsc => contracts.OrderBy(x => x.Date),
            ContractOrderState.DateDesc => contracts.OrderByDescending(x => x.Date),
            ContractOrderState.TariffAsc => contracts.OrderBy(x => x.Tariff),
            ContractOrderState.TariffDesc => contracts.OrderByDescending(x => x.Tariff),
            ContractOrderState.EmployeeSurnameAsc => contracts.OrderBy(x => x.EmployeeSurname),
            ContractOrderState.EmployeeSurnameDesc => contracts.OrderByDescending(x => x.EmployeeSurname),
            ContractOrderState.UserSurnameAsc => contracts.OrderBy(x => x.UserSurname),
            ContractOrderState.UserSurnameDesc => contracts.OrderByDescending(x => x.UserSurname),
            ContractOrderState.PhoneNumberAsc => contracts.OrderBy(x => x.PhoneNumber),
            ContractOrderState.PhoneNumberDesc => contracts.OrderByDescending(x => x.PhoneNumber),
            _ => contracts.OrderBy(x => x.Id)
        };
        return contracts;
    }
    #endregion

    [ResponseCache(Duration = 300)]
    public async Task<IActionResult> Create()
    {
        var tariffs = await Mediator.Send(new GetTariffsQuery());
        var employees = await Mediator.Send(new GetEmployeesQuery());
        var users = await Mediator.Send(new GetUsersQuery());

        if (tariffs.StatusCode != Status.BadRequest)
            ViewData["Tariffs"] = new SelectList(tariffs.Data.OrderBy(x => x.Name), "Id", "Name");

        if (employees.StatusCode != Status.BadRequest)
            ViewData["Employees"] = new SelectList(employees.Data.OrderBy(x => x.Surname), "Id", "Surname");

        if (users.StatusCode != Status.BadRequest)
            ViewData["Users"] = new SelectList(users.Data.OrderBy(x => x.Surname), "Id", "Surname");

        return View();
    }

    [HttpPost, ActionName("Create")]
    public async Task<IActionResult> CreatePost(CreateContractCommand vm)
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

        var query = new GetContractByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
               View(response.Data) : NotFound();
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetContractByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        return response.StatusCode == Status.Ok ?
               View(response.Data) : NotFound();
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var command = new DeleteContractCommand((Guid)id);

        var response = await Mediator.Send(command);

        return response.StatusCode == Status.Deleted ?
            RedirectToAction("Index") : BadRequest("Something went wrong");
    }

    public async Task<IActionResult> Edit(Guid? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var query = new GetContractByIdQuery((Guid)id);

        var response = await Mediator.Send(query);

        if (response.StatusCode != Status.Ok)
            return NotFound();

        var tariffs = await Mediator.Send(new GetTariffsQuery());
        var employees = await Mediator.Send(new GetEmployeesQuery());
        var users = await Mediator.Send(new GetUsersQuery());

        if (tariffs.StatusCode == Status.Ok)
            ViewData["Tariffs"] = new SelectList(tariffs.Data.OrderBy(x => x.Name), "Id", "Name");

        if (employees.StatusCode == Status.Ok)
            ViewData["Employees"] = new SelectList(employees.Data.OrderBy(x => x.Surname), "Id", "Surname");

        if (users.StatusCode == Status.Ok)
            ViewData["Users"] = new SelectList(users.Data.OrderBy(x => x.Surname), "Id", "Surname");

        return View(response.Data.ToUpdateViewModel());
    }

    [HttpPost, ActionName("Edit")]
    public async Task<IActionResult> EditPost(UpdateContractCommand vm)
    {
        if (ModelState.IsValid)
        {
            await Mediator.Send(vm);

            return RedirectToAction("Index");
        }

        return View(vm);
    }
}
