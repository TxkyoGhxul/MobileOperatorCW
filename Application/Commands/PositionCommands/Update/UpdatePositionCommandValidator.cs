using FluentValidation;

namespace Application.Commands.PositionCommands.Update;

public class UpdatePositionCommandValidator : AbstractValidator<UpdatePositionCommand>
{
	public UpdatePositionCommandValidator()
	{
        RuleFor(x => x.Id).NotEqual(Guid.Empty);
        RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
        RuleFor(x => x.Salary).GreaterThan(0);
    }
}
