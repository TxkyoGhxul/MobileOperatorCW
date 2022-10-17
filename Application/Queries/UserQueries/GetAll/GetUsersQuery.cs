using Domain;
using MediatR;

namespace Application.Queries.UserQueries.GetAll;
public record GetUsersQuery : IRequest<IEnumerable<User>>;
