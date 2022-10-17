using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.CallQueries.GetById;

public class GetCallByIdQueryHandler : IRequestHandler<GetCallByIdQuery, Call>
{
    private readonly IFullRepository<Call> _repository;

    public GetCallByIdQueryHandler(IFullRepository<Call> repository) =>
        _repository = repository;

    public async Task<Call> Handle(GetCallByIdQuery request, CancellationToken cancellationToken) => 
        await _repository.SelectByIdAsync(request.Id, cancellationToken);
}
