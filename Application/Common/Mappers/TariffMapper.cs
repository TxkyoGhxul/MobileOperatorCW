using Application.Commands.TariffCommands.Create;
using Application.Commands.TariffCommands.Update;
using Domain;

namespace Application.Common.Mappers;
public static class TariffMapper
{
    public static Tariff ToDomain(this CreateTariffCommand command)
    {
        return command == null ? null : new Tariff
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Cost = command.Cost,
            LocalCost = command.LocalCost,
            TownCost = command.TownCost,
            CountryCost = command.CountryCost,
            SMSCost = command.SMSCost,
            MbCost = command.MbCost,
            TariffTypeId = command.TariffTypeId
        };
    }

    public static Tariff ToDomain(this UpdateTariffCommand command)
    {
        return command == null ? null : new Tariff
        {
            Id = command.Id,
            Name = command.Name,
            Cost = command.Cost,
            LocalCost = command.LocalCost,
            TownCost = command.TownCost,
            CountryCost = command.CountryCost,
            SMSCost = command.SMSCost,
            MbCost = command.MbCost,
            TariffTypeId = command.TariffTypeId
        };
    }

    public static UpdateTariffCommand ToDomain(this Tariff model)
    {
        return model == null ? null : new UpdateTariffCommand
        (
            model.Id,
            model.Name,
            model.Cost,
            model.LocalCost,
            model.TownCost,
            model.CountryCost,
            model.SMSCost,
            model.MbCost,
            model.TariffTypeId
        );
    }
}
