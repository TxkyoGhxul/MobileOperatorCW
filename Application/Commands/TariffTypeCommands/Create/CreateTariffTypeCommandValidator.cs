using FluentValidation;

namespace Application.Commands.TariffTypeCommands.Create;
public class CreateTariffTypeCommandValidator : AbstractValidator<CreateTariffTypeCommand>
{
    public CreateTariffTypeCommandValidator() => RuleFor(cmd => cmd.Name).NotEmpty();
}
