using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.UserQueries.GetById;
public record GetUserByIdQuery(Guid Id) : IRequest<IResponse<User>>;
