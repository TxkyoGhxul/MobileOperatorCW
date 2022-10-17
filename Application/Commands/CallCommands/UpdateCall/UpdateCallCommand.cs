using Domain;
using MediatR;

namespace Application.Commands.CallCommands.UpdateCall;

public record UpdateCallCommand(Guid Id, Contract Contract, TimeSpan TimeSpan, DateTime Date) : IRequest;
