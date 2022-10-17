using Domain;
using MediatR;

namespace Application.Queries.PositionQueries.GetAll;
public record GetPositionsQuery : IRequest<IEnumerable<Position>>;