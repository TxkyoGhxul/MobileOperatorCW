using FluentValidation;

namespace Application.Commands.TariffCommands.Create;

public class CreateTariffCommandValidator : AbstractValidator<CreateTariffCommand>
{
    public CreateTariffCommandValidator()
    {
        RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
        RuleFor(x => x.Cost).GreaterThan(0);
        RuleFor(x => x.LocalCost).GreaterThan(0);
        RuleFor(x => x.TownCost).GreaterThan(0);
        RuleFor(x => x.CountryCost).GreaterThan(0);
        RuleFor(x => x.SMSCost).GreaterThan(0);
        RuleFor(x => x.MbCost).GreaterThan(0);
        RuleFor(x => x.TariffTypeId).NotEqual(Guid.Empty);
    }
}
