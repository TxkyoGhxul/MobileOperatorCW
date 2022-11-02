using Application.Interfaces;
using MediatR;

namespace Application.Commands.PositionCommands.Delete;
public record DeletePositionCommand(Guid Id) : IRequest<IResponse<Unit>>;
