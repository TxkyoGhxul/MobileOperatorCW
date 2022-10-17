using FluentValidation;

namespace Application.Commands.PositionCommands.Delete;

public class DeletePositionCommandValidator : AbstractValidator<DeletePositionCommand>
{
	public DeletePositionCommandValidator() => RuleFor(x => x.Id).NotEqual(Guid.Empty);
}
