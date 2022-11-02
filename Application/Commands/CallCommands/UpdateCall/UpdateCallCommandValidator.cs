using FluentValidation;

namespace Application.Commands.CallCommands.UpdateCall;

public class UpdateCallCommandValidator : AbstractValidator<UpdateCallCommand>
{
    public UpdateCallCommandValidator()
    {
        RuleFor(cmd => cmd.Id).NotEmpty().NotEqual(Guid.Empty);
        RuleFor(cmd => cmd.ContractId).NotEqual(Guid.Empty);
        RuleFor(cmd => cmd.TimeSpan.TotalMilliseconds).GreaterThan(0);
        RuleFor(cmd => cmd.Date).LessThan(DateTime.Now);
    }
}
