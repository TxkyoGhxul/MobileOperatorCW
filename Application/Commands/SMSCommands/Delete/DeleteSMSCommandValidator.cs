using FluentValidation;

namespace Application.Commands.SMSCommands.Delete;

public class DeleteSMSCommandValidator : AbstractValidator<DeleteSMSCommand>
{
	public DeleteSMSCommandValidator() => RuleFor(x => x.Id).NotEqual(Guid.Empty);
}
