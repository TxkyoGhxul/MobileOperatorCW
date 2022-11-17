using Application.Commands.ContractCommands.Create;
using Application.Commands.ContractCommands.Update;
using Application.ViewModels.IndexViewModels;
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
            Date = command.Date.ToDateTime(TimeOnly.FromTimeSpan(TimeSpan.Zero)),
            PhoneNumber = command.PhoneNumber
        };
    }

    public static UpdateContractCommand ToUpdateViewModel(this Contract model)
    {
        return model == null ? null : new UpdateContractCommand
        (
            model.Id,
            DateOnly.FromDateTime(model.Date),
            model.PhoneNumber,
            model.UserId,
            model.EmployeeId,
            model.TariffId
        );
    }

    public static IndexContractViewModel ToIndexViewModel(this Contract model)
    {
        return model == null ? null : new IndexContractViewModel
        {
            Id = model.Id,
            PhoneNumber = model.PhoneNumber,
            Date = DateOnly.FromDateTime(model.Date),
            EmployeeSurname = model.Employee.Surname,
            UserSurname = model.User.Surname,
            Tariff = model.Tariff.Name
        };
    }
}
