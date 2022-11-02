using Application.Interfaces;
using MediatR;

namespace Application.Commands.CallCommands.CreateCall;
public record CreateCallCommand(Guid ContractId, TimeSpan TimeSpan, DateTime Date)
    : IRequest<IResponse<Guid>>;
