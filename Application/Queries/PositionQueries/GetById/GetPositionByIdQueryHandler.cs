using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.PositionQueries.GetById;
public class GetPositionByIdQueryHandler : IRequestHandler<GetPositionByIdQuery, Position>
{
    private readonly IFullRepository<Position> _repository;

    public GetPositionByIdQueryHandler(IFullRepository<Position> repository) =>
        _repository = repository;

    public async Task<Position> Handle(GetPositionByIdQuery request, CancellationToken cancellationToken) => 
        await _repository.SelectByIdAsync(request.Id, cancellationToken);
}
