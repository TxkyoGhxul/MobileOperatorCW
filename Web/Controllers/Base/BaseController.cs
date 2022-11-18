using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Base;
public abstract class BaseController : Controller
{
    private IMediator? _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
