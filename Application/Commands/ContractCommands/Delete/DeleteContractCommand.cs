using Application.Interfaces;
using MediatR;

namespace Application.Commands.ContractCommands.Delete;
public record DeleteContractCommand(Guid Id) : IRequest<IResponse<Unit>>;
