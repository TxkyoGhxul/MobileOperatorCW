using Application.Interfaces;
using MediatR;

namespace Application.Commands.PositionCommands.Create;
public record CreatePositionCommand(string Name, decimal Salary) : IRequest<IResponse<Guid>>;
