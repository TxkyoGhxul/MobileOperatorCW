using FluentValidation;

namespace Application.Commands.EmployeeCommands.Delete;
public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
{
	public DeleteEmployeeCommandValidator() => RuleFor(x => x.Id).NotEqual(Guid.Empty);
}
