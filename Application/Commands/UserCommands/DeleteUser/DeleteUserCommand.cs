using Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.UserCommands.DeleteUser;
public record DeleteUserCommand([Required][Display(Name = "Идентификатор")] Guid Id) :
    IRequest<IResponse<Unit>>;
