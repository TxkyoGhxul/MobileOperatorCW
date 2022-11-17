using Application.Commands.UserCommands.CreateUser;
using Application.Commands.UserCommands.UpdateUser;
using Application.ViewModels.IndexViewModels;
using Domain;

namespace Application.Common.Mappers;
public static class UserMapper
{
    public static User ToDomain(this CreateUserCommand command)
    {
        return command == null ? null : new User
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Surname = command.Surname,
            MiddleName = command.MiddleName,
            Adress = command.Adress,
            Passport = command.Passport
        };
    }

    public static User ToDomain(this UpdateUserCommand command)
    {
        return command == null ? null : new User
        {
            Id = command.Id,
            Name = command.Name,
            Surname = command.Surname,
            MiddleName = command.MiddleName,
            Adress = command.Adress,
            Passport = command.Passport
        };
    }

    public static UpdateUserCommand ToUpdateViewModel(this User model)
    {
        return model == null ? null : new UpdateUserCommand
        (
            model.Id,
            model.Name,
            model.Surname,
            model.MiddleName,
            model.Adress,
            model.Passport
        );
    }

    public static IndexUserViewModel ToIndexViewModel(this User model)
    {
        return model == null ? null : new IndexUserViewModel
        {
            Id = model.Id,
            Name = model.Name,
            Surname = model.Surname,
            MiddleName = model.MiddleName,
            Passport = model.Passport
        };
    }
}
