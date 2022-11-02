using Application.Interfaces;

namespace Application.Common.Responses;
public class Response<T> : IResponse<T>
{
    public T Data { get; set; }
    public string Description { get; set; }
    public StatusCode StatusCode { get; set; }

    public Response(string description, StatusCode statusCode = StatusCode.BadRequest)
    {
        Description = description;
        StatusCode = statusCode;
    }

    public Response(T data, StatusCode statusCode = StatusCode.Ok)
    {
        Data = data;
        StatusCode = statusCode;
    }

    public Response(T data, string description, StatusCode statusCode)
    {
        Data = data;
        Description = description;
        StatusCode = statusCode;
    }
}
