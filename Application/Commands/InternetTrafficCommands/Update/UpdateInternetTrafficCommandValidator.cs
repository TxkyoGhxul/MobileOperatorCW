using FluentValidation;

namespace Application.Commands.InternetTrafficCommands.Update;

public class UpdateInternetTrafficCommandValidator : 
    AbstractValidator<UpdateInternetTrafficCommand>
{
    public UpdateInternetTrafficCommandValidator()
    {
        RuleFor(x => x.Id).NotEqual(Guid.Empty);
        RuleFor(cmd => cmd.ContractId).NotEqual(Guid.Empty);
        RuleFor(cmd => cmd.MbSpent).GreaterThan(0);
    }
}
