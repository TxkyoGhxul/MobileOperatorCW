using Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.TariffTypeCommands.Delete;
public record DeleteTariffTypeCommand([Required][Display(Name = "Идентификатор")] Guid Id) :
    IRequest<IResponse<Unit>>;
