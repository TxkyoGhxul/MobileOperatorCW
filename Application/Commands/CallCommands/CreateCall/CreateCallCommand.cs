using Domain;
using MediatR;

namespace Application.Commands.CallCommands.CreateCall;
public record CreateCallCommand(Contract Contract, TimeSpan TimeSpan, DateTime Date) : IRequest<Guid>;
//public record CreateCallCommand(Guid ContractId, TimeSpan TimeSpan, DateTime Date) : IRequest<Guid>;
