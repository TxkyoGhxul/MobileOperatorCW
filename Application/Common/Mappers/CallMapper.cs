using Application.Commands.CallCommands.CreateCall;
using Application.Commands.CallCommands.UpdateCall;
using Domain;

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

    public static UpdateCallCommand ToUpdateCommand(this Call model)
    {
        return model == null ? null : new UpdateCallCommand
        (
            model.Id,
            model.ContractId,
            model.TimeSpan,
            model.Date
        );
    }
}
