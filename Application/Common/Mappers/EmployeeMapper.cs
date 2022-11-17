using Application.Commands.EmployeeCommands.Create;
using Application.Commands.EmployeeCommands.Update;
using Application.ViewModels.IndexViewModels;
using Domain;

namespace Application.Common.Mappers;
public static class EmployeeMapper
{
    public static Employee ToDomain(this CreateEmployeeCommand command)
    {
        return command == null ? null : new Employee
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Surname = command.Surname,
            MiddleName = command.MiddleName,
            PositionId = command.PositionId
        };
    }

    public static Employee ToDomain(this UpdateEmployeeCommand command)
    {
        return command == null ? null : new Employee
        {
            Id = command.Id,
            Name = command.Name,
            Surname = command.Surname,
            MiddleName = command.MiddleName,
            PositionId = command.PositionId
        };
    }

    public static UpdateEmployeeCommand ToUpdateViewModel(this Employee model)
    {
        return model == null ? null : new UpdateEmployeeCommand
        (
            model.Id,
            model.Name,
            model.Surname,
            model.MiddleName,
            model.PositionId
        );
    }

    public static IndexEmployeeViewModel ToIndexViewModel(this Employee model)
    {
        return model == null ? null : new IndexEmployeeViewModel
        {
            Id = model.Id,
            Name = model.Name,
            Surname = model.Surname,
            MiddleName = model.MiddleName,
            Position = model.Position.Name
        };
    }
}
