using FluentValidation;

namespace Application.Commands.PositionCommands.Create;

public class CreatePositionCommandValidator : AbstractValidator<CreatePositionCommand>
{
    public CreatePositionCommandValidator()
    {
        RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
        RuleFor(x => x.Salary).GreaterThan(0);
    }
}
