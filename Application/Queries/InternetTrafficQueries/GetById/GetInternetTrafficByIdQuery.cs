using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.InternetTrafficQueries.GetById;
public record GetInternetTrafficByIdQuery(Guid Id) : IRequest<IResponse<InternetTraffic>>;
