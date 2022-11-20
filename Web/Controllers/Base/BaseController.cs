using Application.Common.OrderStates;
using Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Web.Controllers.Base;
public abstract class BaseController : Controller
{
    private IMediator? _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    protected readonly ControllerConstraints _constraints;

    protected BaseController(string controllerName) => _constraints = new ControllerConstraints(controllerName);

    protected virtual void RewriteValuesInSession<T>(string filter, int page, int pageSize,
        T orderState)
    {
        HttpContext.Session.Remove(_constraints.INDEX_CURRENT_PAGE);
        HttpContext.Session.Remove(_constraints.INDEX_PAGE_SIZE);
        HttpContext.Session.Remove(_constraints.INDEX_ORDER_STATE);
        HttpContext.Session.Remove(_constraints.INDEX_TEXT_FILTER_KEY);
        HttpContext.Session.SetString(_constraints.INDEX_CURRENT_PAGE, page.ToString());
        HttpContext.Session.SetString(_constraints.INDEX_PAGE_SIZE, pageSize.ToString());
        HttpContext.Session.SetString(_constraints.INDEX_ORDER_STATE, orderState.ToString());
        HttpContext.Session.SetString(_constraints.INDEX_TEXT_FILTER_KEY, filter);
    }

    protected virtual string GetFilterFromSessionOrSetDefaultValue()
    {
        return HttpContext.Session.Keys.Contains(_constraints.INDEX_TEXT_FILTER_KEY) ?
            HttpContext.Session.GetString(_constraints.INDEX_TEXT_FILTER_KEY) :
            string.Empty;
    }

    protected virtual int GetCurrentPageFromSessionOrSetDefaultValue()
    {
        return HttpContext.Session.Keys.Contains(_constraints.INDEX_CURRENT_PAGE) ?
            Convert.ToInt32(HttpContext.Session.GetString(_constraints.INDEX_CURRENT_PAGE)) :
            PageViewModel.DEFAULT_CURRENT_PAGE;
    }

    protected virtual int GetPageSizeFromSessionOrSetDefaultValue()
    {
        return HttpContext.Session.Keys.Contains(_constraints.INDEX_PAGE_SIZE) ?
            Convert.ToInt32(HttpContext.Session.GetString(_constraints.INDEX_PAGE_SIZE)) :
            PageViewModel.DEFAULT_PAGE_SIZE;
    }

    protected virtual T GetOrderStateFromSessionOrSetDefaultValue<T>()
    {
        return HttpContext.Session.Keys.Contains(_constraints.INDEX_ORDER_STATE) ?
               (T)Enum.Parse(typeof(T),
                   HttpContext.Session.GetString(_constraints.INDEX_ORDER_STATE)) :
               default;
    }
}
