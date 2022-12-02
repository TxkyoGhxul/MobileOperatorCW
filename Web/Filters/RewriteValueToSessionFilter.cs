using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Filters;
public class RewriteValueToSessionFilter : Attribute, IActionFilter
{
    private readonly string _sessionKey;
    private readonly string _sessionValue;

    public RewriteValueToSessionFilter(string sessionKey, string sessionValue)
    {
        _sessionKey = sessionKey;
        _sessionValue = sessionValue;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        context.HttpContext.Session.Remove(_sessionKey);
        context.HttpContext.Session.SetString(_sessionKey, _sessionValue);
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }
}
