using Domain;
using MediatR;

namespace Application.Queries.TariffTypeQueries.GetAll;
public record GetTariffTypesQuery : IRequest<IEnumerable<TariffType>>;
