using FluentValidation;

namespace Application.Commands.UserCommands.CreateUser;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
	public CreateUserCommandValidator()
	{
		RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
		RuleFor(x => x.Surname).MinimumLength(3).NotEmpty();
		RuleFor(x => x.MiddleName).MinimumLength(3).NotEmpty();
		RuleFor(x => x.Adress).MinimumLength(10).NotEmpty();
		RuleFor(x => x.Passport).MinimumLength(7).NotEmpty();
	}
}
