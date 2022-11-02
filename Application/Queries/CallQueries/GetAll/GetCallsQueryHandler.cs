using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.CallQueries.GetAll;

public class GetCallsQueryHandler : IRequestHandler<GetCallsQuery, IResponse<IEnumerable<Call>>>
{
    private readonly IFullRepository<Call> _repository;

    public GetCallsQueryHandler(IFullRepository<Call> repository) =>
        _repository = repository;

    public async Task<IResponse<IEnumerable<Call>>> Handle(GetCallsQuery request, 
        CancellationToken ct)
    {
        return await _repository.SelectAllAsync(ct);
    }
}
