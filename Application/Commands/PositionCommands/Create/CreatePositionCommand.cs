using MediatR;

namespace Application.Commands.PositionCommands.Create;
public record CreatePositionCommand(string Name, decimal Salary) : IRequest<Guid>;
