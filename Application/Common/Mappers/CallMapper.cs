using Application.Commands.CallCommands.CreateCall;
using Application.Commands.CallCommands.UpdateCall;
using Application.ViewModels.IndexViewModels;
using Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Common.Mappers;
public static class CallMapper
{
    public static Call ToDomain(this CreateCallCommand command)
    {
        return command == null ? null : new Call
        {
            Id = Guid.NewGuid(),
            ContractId = command.ContractId,
            Date = command.Date,
            TimeSpan = command.TimeSpan
        };
    }

    public static Call ToDomain(this UpdateCallCommand command)
    {
        return command == null ? null : new Call
        {
            Id = command.Id,
            ContractId = command.ContractId,
            Date = command.Date,
            TimeSpan = command.TimeSpan
        };
    }

    public static UpdateCallCommand ToUpdateViewModel(this Call model)
    {
        return model == null ? null : new UpdateCallCommand
        (
            model.Id,
            model.ContractId,
            model.TimeSpan,
            model.Date
        );
    }

    public static IndexCallViewModel ToIndexViewModel(this Call model)
    {
        return model == null ? null : new IndexCallViewModel
        {
            Id = model.Id,
            //PhoneNumber = model.Contract.PhoneNumber,
            Date = model.Date,
            TimeSpan = model.TimeSpan
        };
    }
}
