using FluentValidation;

namespace Application.Commands.TariffTypeCommands.Update;
public class UpdateTariffTypeCommandValidator : AbstractValidator<UpdateTariffTypeCommand>
{
    public UpdateTariffTypeCommandValidator()
    {
        RuleFor(cmd => cmd.Id).NotEmpty().NotEqual(Guid.Empty);
        RuleFor(cmd => cmd.Name).NotEmpty();
    }
}
