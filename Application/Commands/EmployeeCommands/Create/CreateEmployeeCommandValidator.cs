using FluentValidation;

namespace Application.Commands.EmployeeCommands.Create;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
	public CreateEmployeeCommandValidator()
	{
        RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
        RuleFor(x => x.Surname).MinimumLength(3).NotEmpty();
        RuleFor(x => x.MiddleName).MinimumLength(3).NotEmpty();
        RuleFor(x => x.PositionId).NotEqual(Guid.Empty);
    }
}
