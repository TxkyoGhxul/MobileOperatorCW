using Application.Queries.TariffTypeQueries.GetAll;
using Application.Queries.UserQueries.GetAll;
using Application.Queries.UserQueries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
public class UserController : Controller
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator) => _mediator = mediator;

    public IActionResult Index() => View();

    public async Task<IActionResult> AllUsers()
    {
        GetUsersQuery query = new GetUsersQuery();
        var users = await _mediator.Send(query);
        return View(users);
    }

    public async Task<IActionResult> TariffTypes()
    {
        var query = new GetTariffTypesQuery();
        var response = await _mediator.Send(query);
        return response.StatusCode != Application.Common.Responses.StatusCode.Created ?
            BadRequest(response.Description) : View(response.Data);
    }

    [HttpGet]
    public async Task<IActionResult> UserInfo(Guid id)
    {
        GetUserByIdQuery query = new GetUserByIdQuery(id);
        var user = await _mediator.Send(query);
        return View(user);
    }

    [HttpPost]
    [ActionName("Filter")]
    public async Task<IActionResult> OnPostFilter(string? filterText)
    {
        var query = new GetUsersQuery();
        var allUsers = await _mediator.Send(query);
        var users = allUsers.Where(x => x.Name.Contains(filterText, StringComparison.InvariantCultureIgnoreCase)).ToList();
        return View(users);
    }

    //[HttpGet("{id}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //public async Task<IActionResult> Get(int? id)
    //{
    //    GetUserByIdQuery query = new GetUserByIdQuery(id ?? 10);
    //    var user = await _mediator.Send(query);
    //    return View("User", user);
    //    //return Ok(id);
    //}
}
