using Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.ContractCommands.Create;
public record CreateContractCommand(
    [Display(Name = "Дата заключения договора")]
    [DataType(DataType.DateTime, ErrorMessage = "Введите дату заключения договора")] 
    DateTime Date,

    [Display(Name = "Номер телефона")]
    [DataType(DataType.PhoneNumber)]
    string PhoneNumber,

    [Display(Name = "Идентификатор пользователя")]
    Guid UserId,

    [Display(Name = "Идентификатор сотрудника")]
    Guid EmployeeId,

    [Display(Name = "Идентификатор тарифа")]
    Guid TariffId) : IRequest<IResponse<Guid>>;
