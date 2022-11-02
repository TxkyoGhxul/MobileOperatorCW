using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.TariffQueries.GetById;
public record GetTariffByIdQuery(Guid Id) : IRequest<IResponse<Tariff>>;