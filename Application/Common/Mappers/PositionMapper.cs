using Application.Commands.PositionCommands.Create;
using Application.Commands.PositionCommands.Update;
using Application.ViewModels.IndexViewModels;
using Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

    public static UpdatePositionCommand ToUpdateViewModel(this Position model)
    {
        return model == null ? null : new UpdatePositionCommand
        (
            model.Id,
            model.Name,
            model.Salary
        );
    }

    public static IndexPositionViewModel ToIndexViewModel(this Position model)
    {
        return model == null ? null : new IndexPositionViewModel
        {
            Id = model.Id,
            Name = model.Name,
            Salary = model.Salary
        };
    }
}
