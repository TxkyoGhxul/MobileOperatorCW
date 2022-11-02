using Application.Commands.PositionCommands.Create;
using Application.Commands.PositionCommands.Update;
using Domain;

namespace Application.Common.Mappers;
public static class PositionMapper
{
    public static Position ToDomain(this CreatePositionCommand command)
    {
        return command == null ? null : new Position
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Salary = command.Salary
        };
    }

    public static Position ToDomain(this UpdatePositionCommand command)
    {
        return command == null ? null : new Position
        {
            Id = command.Id,
            Name = command.Name,
            Salary = command.Salary
        };
    }

    public static UpdatePositionCommand ToDomain(this Position model)
    {
        return model == null ? null : new UpdatePositionCommand
        (
            model.Id,
            model.Name,
            model.Salary
        );
    }
}
