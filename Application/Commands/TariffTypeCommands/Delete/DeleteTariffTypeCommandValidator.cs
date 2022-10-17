using FluentValidation;

namespace Application.Commands.TariffTypeCommands.Delete;
public class DeleteTariffTypeCommandValidator : AbstractValidator<DeleteTariffTypeCommand>
{
    public DeleteTariffTypeCommandValidator() => 
        RuleFor(cmd => cmd.Id).NotEmpty().NotEqual(Guid.Empty);
}
