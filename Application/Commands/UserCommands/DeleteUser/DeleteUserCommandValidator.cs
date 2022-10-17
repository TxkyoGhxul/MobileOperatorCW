using FluentValidation;

namespace Application.Commands.UserCommands.DeleteUser;
public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
	public DeleteUserCommandValidator() => RuleFor(x => x.Id).NotEqual(Guid.Empty);
}
