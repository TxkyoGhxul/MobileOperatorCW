using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.PositionQueries.GetAll;

public class GetPositionsQueryHandler : IRequestHandler<GetPositionsQuery, IEnumerable<Position>>
{
    private readonly IFullRepository<Position> _repository;

    public GetPositionsQueryHandler(IFullRepository<Position> repository) =>
        _repository = repository;

    public async Task<IEnumerable<Position>> Handle(GetPositionsQuery request, CancellationToken cancellationToken) =>
        await _repository.SelectAllAsync(cancellationToken);
}
