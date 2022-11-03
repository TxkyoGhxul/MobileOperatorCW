using Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.CallCommands.DeleteCall;
public record DeleteCallCommand([Required] [Display(Name = "Идентификатор")] Guid Id)
    : IRequest<IResponse<Unit>>;
