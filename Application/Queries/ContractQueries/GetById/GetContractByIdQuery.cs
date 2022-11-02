using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.ContractQueries.GetById;
public record GetContractByIdQuery(Guid Id) : IRequest<IResponse<Contract>>;
