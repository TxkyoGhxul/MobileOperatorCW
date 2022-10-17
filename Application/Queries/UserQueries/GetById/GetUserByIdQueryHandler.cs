using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.UserQueries.GetById;
public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
{
    private readonly IFullRepository<User> _repository;

    public GetUserByIdQueryHandler(IFullRepository<User> repository) => _repository = repository;

    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) => 
        await _repository.SelectByIdAsync(request.Id, cancellationToken);
}
