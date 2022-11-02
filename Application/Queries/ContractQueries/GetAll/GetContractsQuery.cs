using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.ContractQueries.GetAll;
public record GetContractsQuery : IRequest<IResponse<IEnumerable<Contract>>>;
