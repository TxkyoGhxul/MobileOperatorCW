using Domain;
using MediatR;

namespace Application.Queries.InternetTrafficQueries.GetById;
public record GetInternetTrafficByIdQuery(Guid Id) : IRequest<InternetTraffic>;
