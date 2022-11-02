using FluentValidation;

namespace Application.Commands.CallCommands.DeleteCall;

public class DeleteCallCommandValidator : AbstractValidator<DeleteCallCommand>
{
    public DeleteCallCommandValidator() => RuleFor(cmd => cmd.Id).NotEqual(Guid.Empty);
}
