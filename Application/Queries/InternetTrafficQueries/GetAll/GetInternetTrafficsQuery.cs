using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.InternetTrafficQueries.GetAll;
public record GetInternetTrafficsQuery : IRequest<IResponse<IEnumerable<InternetTraffic>>>;
