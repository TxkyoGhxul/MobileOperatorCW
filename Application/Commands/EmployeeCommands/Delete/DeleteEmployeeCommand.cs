using Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.EmployeeCommands.Delete;
public record DeleteEmployeeCommand([Required][Display(Name = "Идентификатор")] Guid Id) :
    IRequest<IResponse<Unit>>;
