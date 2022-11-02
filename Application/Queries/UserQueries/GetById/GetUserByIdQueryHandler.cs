using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.UserQueries.GetById;
public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, IResponse<User>>
{
    private readonly IFullRepository<User> _repository;

    public GetUserByIdQueryHandler(IFullRepository<User> repository) => _repository = repository;

    public async Task<IResponse<User>> Handle(GetUserByIdQuery request, CancellationToken ct)
    {
        try
        {
            var response = await _repository.SelectByIdAsync(request.Id, ct);

            return new Response<User>(response);
        }
        catch (Exception ex)
        {
            return new Response<User>(ex.Message);
        }
    }
}
