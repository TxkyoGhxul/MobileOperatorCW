using Application.Interfaces;

namespace Application.Common.Responses;
public class Response<T> : IResponse<T>
{
    public T Data { get; set; }
    public string Description { get; set; }
    public Status StatusCode { get; set; }

    public Response(string description, Status statusCode = Status.BadRequest)
    {
        Description = description;
        StatusCode = statusCode;
    }

    public Response(T data, Status statusCode = Status.Ok)
    {
        Data = data;
        StatusCode = statusCode;
    }

    public Response(T data, string description, Status statusCode)
    {
        Data = data;
        Description = description;
        StatusCode = statusCode;
    }
}
