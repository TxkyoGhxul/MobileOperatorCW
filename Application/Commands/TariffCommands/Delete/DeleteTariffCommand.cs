using Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.TariffCommands.Delete;
public record DeleteTariffCommand([Required][Display(Name = "Идентификатор")] Guid Id) :
    IRequest<IResponse<Unit>>;
