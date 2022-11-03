using Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.UserCommands.UpdateUser;
public record UpdateUserCommand([Display(Name = "Идентификатор")] Guid Id,

    [Display(Name = "Имя пользователя")]
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Имя пользователя должно содержать от 3 до 25 символов")]
    string Name,

    [Display(Name = "Фамилия пользователя")]
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Фамилия пользователя должна содержать от 3 до 25 символов")]
    string Surname,

    [Display(Name = "Отчество пользователя")]
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Отчество пользователя должно содержать от 3 до 25 символов")]
    string MiddleName,

    [Display(Name = "Адрес")]
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Адрес должен содержать от 3 до 25 символов")]
    string Adress,

    [Display(Name = "Паспорт")]
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Паспорт должен содержать от 3 до 25 символов")]
    string Passport) : IRequest<IResponse<Unit>>;
