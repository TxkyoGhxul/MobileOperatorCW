using Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.PositionCommands.Create;
public record CreatePositionCommand(
    [Display(Name = "Должность")]
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Название должности должно содержать от 3 до 25 символов")]
    string Name,

    [Display(Name = "Зарплата")]
    decimal Salary) : IRequest<IResponse<Guid>>;
