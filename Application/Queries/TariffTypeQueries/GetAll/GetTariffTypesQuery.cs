using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.TariffTypeQueries.GetAll;
public record GetTariffTypesQuery : IRequest<IResponse<IEnumerable<TariffType>>>;
