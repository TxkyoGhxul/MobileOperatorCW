using Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.SMSCommands.Create;
public record CreateSMSCommand([Display(Name = "Идентификатор договора")] Guid ContractId,

    [Display(Name = "Время отправки смс")]
    [DataType(DataType.DateTime)]
    DateTime Date,

    [Display(Name = "Сообщение")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Сообщение должно содержать от 1 до 100 символов")]
    string Message) : IRequest<IResponse<Guid>>;
