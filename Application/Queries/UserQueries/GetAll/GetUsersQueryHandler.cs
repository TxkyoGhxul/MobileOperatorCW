using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.UserQueries.GetAll;
public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
{
    private readonly IFullRepository<User> _repository;

    public GetUsersQueryHandler(IFullRepository<User> repository) => _repository = repository;

    public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken) => 
        await _repository.SelectAllAsync(cancellationToken);
}
