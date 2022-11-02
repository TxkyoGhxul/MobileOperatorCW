using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.PositionQueries.GetById;
public class GetPositionByIdQueryHandler : 
    IRequestHandler<GetPositionByIdQuery, IResponse<Position>>
{
    private readonly IFullRepository<Position> _repository;

    public GetPositionByIdQueryHandler(IFullRepository<Position> repository) =>
        _repository = repository;

    public async Task<IResponse<Position>> Handle(GetPositionByIdQuery request, 
        CancellationToken cancellationToken)
    {
        return await _repository.SelectByIdAsync(request.Id, cancellationToken);
    }
}
