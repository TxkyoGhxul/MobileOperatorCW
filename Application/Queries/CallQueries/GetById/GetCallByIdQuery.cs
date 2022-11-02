using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.CallQueries.GetById;
public record GetCallByIdQuery(Guid Id) : IRequest<IResponse<Call>>;
