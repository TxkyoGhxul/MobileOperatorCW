using FluentValidation;

namespace Application.Commands.ContractCommands.Create;
public class CreateContractCommandValidator : AbstractValidator<CreateContractCommand>
{
	public CreateContractCommandValidator()
	{
        RuleFor(cmd => cmd.PhoneNumber).NotEmpty();
        RuleFor(cmd => cmd.UserId).NotEqual(Guid.Empty);
        RuleFor(cmd => cmd.EmployeeId).NotEqual(Guid.Empty);
        RuleFor(cmd => cmd.TariffId).NotEqual(Guid.Empty);
    }
}
