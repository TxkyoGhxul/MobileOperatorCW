using Application.Commands.EmployeeCommands.Create;
using Application.Commands.EmployeeCommands.Update;
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

    public static UpdateEmployeeCommand ToDomain(this Employee model)
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
}
