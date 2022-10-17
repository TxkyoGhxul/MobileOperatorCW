using FluentValidation;

namespace Application.Commands.SMSCommands.Update;

public class UpdateSMSCommandValidator : AbstractValidator<UpdateSMSCommand>
{
	public UpdateSMSCommandValidator()
	{
        RuleFor(x => x.Id).NotEqual(Guid.Empty);
        RuleFor(cmd => cmd.ContractId).NotEqual(Guid.Empty);
        RuleFor(x => x.Message).MinimumLength(1).NotEmpty();
    }
}
