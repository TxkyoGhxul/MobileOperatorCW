using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.Base;

//[ApiController]
//[Route("api/[controller]/[action]")]
public abstract class BaseController : Controller
{
    private IMediator? _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
