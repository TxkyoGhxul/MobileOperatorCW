using Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.EmployeeCommands.Create;
public record CreateEmployeeCommand(
    [Display(Name = "Имя сотрудника")]
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Имя должно содержать от 3 до 25 символов")]
    string Name,

    [Display(Name = "Фамилия сотрудника")]
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Фамилия должно содержать от 3 до 25 символов")]
    string Surname,

    [Display(Name = "Отчество сотрудника")]
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Отчество должно содержать от 3 до 25 символов")]
    string MiddleName,

    [Display(Name = "Идентификатор должности")]
    Guid PositionId) : IRequest<IResponse<Guid>>;
