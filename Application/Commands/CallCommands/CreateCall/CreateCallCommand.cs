using Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.CallCommands.CreateCall;
public record CreateCallCommand([Display(Name = "Идентификатор контракта")] Guid ContractId,
    [Display(Name = "Длительность разговора")] TimeSpan TimeSpan,
    [Display(Name = "Дата звонка")] 
    [DataType(DataType.DateTime, ErrorMessage = "Введите дату")] DateTime Date)
    : IRequest<IResponse<Guid>>;
