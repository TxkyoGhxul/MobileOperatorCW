using Application.Interfaces;
using MediatR;

namespace Application.Commands.CallCommands.UpdateCall;

public record UpdateCallCommand(Guid Id, Guid ContractId, TimeSpan TimeSpan, DateTime Date)
    : IRequest<IResponse<Unit>>;
