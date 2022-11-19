using FluentValidation;
using System.Net;
using System.Text.Json;

namespace Web.Middlewares;
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (ValidationException ex)
        {
            await HandleExceptionAsync(httpContext, ex.Message,
                HttpStatusCode.BadRequest, "Ошибка валидации!");
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex.Message, 
                HttpStatusCode.InternalServerError, "Что-то пошло не так!");
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, 
        string exceptionMessage, HttpStatusCode statusCode, string message)
    {
        HttpResponse response = httpContext.Response;

        response.ContentType = "application/json";
        response.StatusCode = (int)statusCode;

        var error = new
        {
            Message = message,
            ExceptionMessage = exceptionMessage,
            StatusCode = statusCode
        };

        string result = JsonSerializer.Serialize(error);

        await response.WriteAsJsonAsync(result);

        httpContext.Response.StatusCode = (int)statusCode;
        await httpContext.Response.WriteAsync(message);
    }
}
