using FluentValidation;

namespace Application.Commands.InternetTrafficCommands.Delete;

public class DeleteInternetTrafficCommandValidator : 
	AbstractValidator<DeleteInternetTrafficCommand>
{
	public DeleteInternetTrafficCommandValidator() => RuleFor(x => x.Id).NotEqual(Guid.Empty);
}
