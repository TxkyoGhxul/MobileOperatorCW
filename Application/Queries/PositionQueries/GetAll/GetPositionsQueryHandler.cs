using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.PositionQueries.GetAll;

public class GetPositionsQueryHandler : 
    IRequestHandler<GetPositionsQuery, IResponse<IEnumerable<Position>>>
{
    private readonly IFullRepository<Position> _repository;

    public GetPositionsQueryHandler(IFullRepository<Position> repository) =>
        _repository = repository;

    public async Task<IResponse<IEnumerable<Position>>> Handle(GetPositionsQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.SelectAllAsync(cancellationToken);
    }
}
