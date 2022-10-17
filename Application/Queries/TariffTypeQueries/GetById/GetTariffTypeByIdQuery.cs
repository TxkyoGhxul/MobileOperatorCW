using Domain;
using MediatR;

namespace Application.Queries.TariffTypeQueries.GetById;
public record GetTariffTypeByIdQuery(Guid Id) : IRequest<TariffType>;
