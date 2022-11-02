using Application.Commands.ContractCommands.Create;
using Application.Commands.ContractCommands.Update;
using Domain;

namespace Application.Common.Mappers;
public static class ContractMapper
{
    public static Contract ToDomain(this CreateContractCommand command)
    {
        return command == null ? null : new Contract
        {
            Id = Guid.NewGuid(),
            UserId = command.UserId,
            EmployeeId = command.EmployeeId,
            TariffId = command.TariffId,
            Date = command.Date,
            PhoneNumber = command.PhoneNumber
        };
    }

    public static Contract ToDomain(this UpdateContractCommand command)
    {
        return command == null ? null : new Contract
        {
            Id = command.Id,
            UserId = command.UserId,
            EmployeeId = command.EmployeeId,
            TariffId = command.TariffId,
            Date = command.Date,
            PhoneNumber = command.PhoneNumber
        };
    }

    public static UpdateContractCommand ToUpdateCommand(this Contract model)
    {
        return model == null ? null : new UpdateContractCommand
        (
            model.Id,
            model.Date,
            model.PhoneNumber,
            model.UserId,
            model.EmployeeId,
            model.TariffId
        );
    }
}
