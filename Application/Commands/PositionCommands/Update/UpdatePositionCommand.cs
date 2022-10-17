using MediatR;

namespace Application.Commands.PositionCommands.Update;
public record UpdatePositionCommand(Guid Id, string Name, decimal Salary) : IRequest;
