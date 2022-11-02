using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.PositionQueries.GetById;
public record GetPositionByIdQuery(Guid Id) : IRequest<IResponse<Position>>;