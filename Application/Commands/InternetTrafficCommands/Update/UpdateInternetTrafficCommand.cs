using Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.InternetTrafficCommands.Update;
public record UpdateInternetTrafficCommand([Display(Name = "Идентификатор")] Guid Id,
    [Display(Name = "Идентификатор договора")] Guid ContractId,

    [Display(Name = "Дата")]
    [DataType(DataType.DateTime, ErrorMessage = "Введите дату")]
    DateTime Date,

    [Display(Name = "Потрачено мб")]
    int MbSpent) : IRequest<IResponse<Unit>>;
