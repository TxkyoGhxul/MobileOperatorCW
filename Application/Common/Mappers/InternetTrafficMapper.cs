using Application.Commands.InternetTrafficCommands.Create;
using Application.Commands.InternetTrafficCommands.Update;
using Domain;

namespace Application.Common.Mappers;
public static class InternetTrafficMapper
{
    public static InternetTraffic ToDomain(this CreateInternetTrafficCommand command)
    {
        return command == null ? null : new InternetTraffic
        {
            Id = Guid.NewGuid(),
            ContractId = command.ContractId,
            MbSpent = command.MbSpent,
            Date = command.Date
        };
    }

    public static InternetTraffic ToDomain(this UpdateInternetTrafficCommand command)
    {
        return command == null ? null : new InternetTraffic
        {
            Id = command.Id,
            ContractId = command.ContractId,
            MbSpent = command.MbSpent,
            Date = command.Date
        };
    }

    public static UpdateInternetTrafficCommand ToUpdateViewModel(this InternetTraffic model)
    {
        return model == null ? null : new UpdateInternetTrafficCommand
        (
            model.Id,
            model.ContractId,
            model.Date,
            model.MbSpent
        );
    }
}
