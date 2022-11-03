using Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.TariffTypeCommands.Update;
public record UpdateTariffTypeCommand([Display(Name = "Идентификатор")] Guid Id,
    [Display(Name = "Тип тарификации")]
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Тип тарификации должен содержать от 3 до 25 символов")]
    string Name) :
    IRequest<IResponse<Unit>>;
