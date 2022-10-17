using FluentValidation;

namespace Application.Commands.InternetTrafficCommands.Create;

public class CreateInternetTrafficCommandValidator : AbstractValidator<CreateInternetTrafficCommand>
{
	public CreateInternetTrafficCommandValidator()
	{
        RuleFor(cmd => cmd.ContractId).NotEqual(Guid.Empty);
        RuleFor(cmd => cmd.MbSpent).GreaterThan(0);
    }
}
