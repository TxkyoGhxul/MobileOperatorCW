using Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.CallCommands.UpdateCall;
public record UpdateCallCommand([Display(Name = "Идентификатор")] Guid Id,
    [Display(Name = "Идентификатор контракта")] Guid ContractId,
    [Display(Name = "Длительность звонка")] TimeSpan TimeSpan,
    [Display(Name = "Дата звонка")]
    [DataType(DataType.DateTime, ErrorMessage = "Введите дату")] DateTime Date)
    : IRequest<IResponse<Unit>>;
