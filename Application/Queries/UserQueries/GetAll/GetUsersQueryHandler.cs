using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.UserQueries.GetAll;
public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IResponse<IEnumerable<User>>>
{
    private readonly IFullRepository<User> _repository;

    public GetUsersQueryHandler(IFullRepository<User> repository) => _repository = repository;

    public async Task<IResponse<IEnumerable<User>>> Handle(GetUsersQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _repository.SelectAllAsync(cancellationToken);

            return new Response<IEnumerable<User>>(response);
        }
        catch (Exception ex)
        {
            return new Response<IEnumerable<User>>(ex.Message);
        }
    }
}
