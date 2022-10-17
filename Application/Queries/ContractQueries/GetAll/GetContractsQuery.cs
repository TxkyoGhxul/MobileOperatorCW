using Domain;
using MediatR;

namespace Application.Queries.ContractQueries.GetAll;
public record GetContractsQuery : IRequest<IEnumerable<Contract>>;
