using Application.Commands.SMSCommands.Create;
using Application.Commands.SMSCommands.Update;
using Application.ViewModels.IndexViewModels;
using Domain;

namespace Application.Common.Mappers;
public static class SMSMapper
{
    public static SMS ToDomain(this CreateSMSCommand command)
    {
        return command == null ? null : new SMS
        {
            Id = Guid.NewGuid(),
            ContractId = command.ContractId,
            Date = command.Date,
            Message = command.Message
        };
    }

    public static SMS ToDomain(this UpdateSMSCommand command)
    {
        return command == null ? null : new SMS
        {
            Id = command.Id,
            ContractId = command.ContractId,
            Date = command.Date,
            Message = command.Message
        };
    }

    public static UpdateSMSCommand ToUpdateViewModel(this SMS model)
    {
        return model == null ? null : new UpdateSMSCommand
        (
            model.Id,
            model.ContractId,
            model.Date,
            model.Message
        );
    }

    public static IndexSMSViewModel ToIndexViewModel(this SMS model)
    {
        return model == null ? null : new IndexSMSViewModel
        {
            Id = model.Id,
            Date = model.Date,
            PhoneNumber = model.Contract.PhoneNumber,
            Message = model.Message
        };
    }
}
