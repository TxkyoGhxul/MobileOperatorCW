using Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.ContractCommands.Delete;
public record DeleteContractCommand([Required][Display(Name = "Идентификатор")] Guid Id) :
    IRequest<IResponse<Unit>>;
