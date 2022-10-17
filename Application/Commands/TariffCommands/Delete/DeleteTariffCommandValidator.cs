using FluentValidation;

namespace Application.Commands.TariffCommands.Delete;

public class DeleteTariffCommandValidator : AbstractValidator<DeleteTariffCommand>
{
    public DeleteTariffCommandValidator() => RuleFor(x => x.Id).NotEqual(Guid.Empty);
}
