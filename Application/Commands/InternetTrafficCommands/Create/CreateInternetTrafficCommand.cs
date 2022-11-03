using Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.InternetTrafficCommands.Create;
public record CreateInternetTrafficCommand([Display(Name = "Идентификатор договора")] Guid ContractId,

    [Display(Name = "Дата")]
    [DataType(DataType.DateTime, ErrorMessage = "Введите дату")]
    DateTime Date,

    [Display(Name = "Потрачено мб")]
    int MbSpent) : IRequest<IResponse<Guid>>;
