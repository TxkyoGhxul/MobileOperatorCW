using FluentValidation;

namespace Application.Commands.CallCommands.CreateCall;

public class CreateCallCommandValidator : AbstractValidator<CreateCallCommand>
{
    public CreateCallCommandValidator()
    {
        RuleFor(cmd => cmd.Contract).NotNull();
        RuleFor(cmd => cmd.TimeSpan.TotalMilliseconds).GreaterThan(0);
        RuleFor(cmd => cmd.Date).LessThan(DateTime.Now);
    }
}
