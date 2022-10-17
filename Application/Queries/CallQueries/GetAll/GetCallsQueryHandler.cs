using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.CallQueries.GetAll;

public class GetCallsQueryHandler : IRequestHandler<GetCallsQuery, IEnumerable<Call>>
{
    private readonly IFullRepository<Call> _repository;

    public GetCallsQueryHandler(IFullRepository<Call> repository) =>
        _repository = repository;

    public async Task<IEnumerable<Call>> Handle(GetCallsQuery request, CancellationToken cancellationToken) => 
        await _repository.SelectAllAsync(cancellationToken);
}
