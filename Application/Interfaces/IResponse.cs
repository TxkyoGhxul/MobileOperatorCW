namespace Application.Interfaces;
public interface IResponse<T>
{
    T Data { get; set; }

    string Description { get; set; }

    StatusCode StatusCode { get; set; }
}

public enum StatusCode
{
    Ok = 200,
    Created = 201,
    Accepted = 202,
    Deleted = 203,
    Updated = 204,
    NotCreated = 205,
    NotDeleted = 206,
    NotUpdated = 207,
    BadRequest = 400,
    NotFound = 404
}