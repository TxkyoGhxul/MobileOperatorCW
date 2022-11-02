using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.TariffQueries.GetAll;
public record GetTariffsQuery : IRequest<IResponse<IEnumerable<Tariff>>>;
