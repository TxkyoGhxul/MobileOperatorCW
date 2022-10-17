using Domain;
using MediatR;

namespace Application.Queries.TariffQueries.GetAll;
public record GetTariffsQuery : IRequest<IEnumerable<Tariff>>;
