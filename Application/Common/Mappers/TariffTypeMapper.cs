using Application.Commands.TariffTypeCommands.Create;
using Application.Commands.TariffTypeCommands.Update;
using Application.ViewModels.IndexViewModels;
using Domain;

namespace Application.Common.Mappers;
public static class TariffTypeMapper
{
    public static TariffType ToDomain(this CreateTariffTypeCommand command)
    {
        return command == null ? null : new TariffType
        {
            Id = Guid.NewGuid(),
            Name = command.Name
        };
    }

    public static TariffType ToDomain(this UpdateTariffTypeCommand command)
    {
        return command == null ? null : new TariffType
        {
            Id = command.Id,
            Name = command.Name
        };
    }

    public static UpdateTariffTypeCommand ToUpdateViewModel(this TariffType model)
    {
        return model == null ? null : new UpdateTariffTypeCommand
        (
            model.Id,
            model.Name
        );
    }

    public static IndexTariffTypeViewModel ToIndexViewModel(this TariffType model)
    {
        return model == null ? null : new IndexTariffTypeViewModel
        {
            Id = model.Id,
            Name = model.Name
        };
    }
}
