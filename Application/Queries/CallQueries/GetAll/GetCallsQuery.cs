using Domain;
using MediatR;

namespace Application.Queries.CallQueries.GetAll;
public record GetCallsQuery : IRequest<IEnumerable<Call>>;
