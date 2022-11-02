using Application.Interfaces;
using MediatR;

namespace Application.Commands.UserCommands.DeleteUser;
public record DeleteUserCommand(Guid Id) : IRequest<IResponse<Unit>>;
