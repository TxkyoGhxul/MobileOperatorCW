using FluentValidation;

namespace Application.Commands.SMSCommands.Create;

public class CreateSMSCommandValidator : AbstractValidator<CreateSMSCommand>
{
	public CreateSMSCommandValidator()
	{
        RuleFor(cmd => cmd.ContractId).NotEqual(Guid.Empty);
        RuleFor(x => x.Message).MinimumLength(1).NotEmpty();
    }
}
