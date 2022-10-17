using FluentValidation;

namespace Application.Commands.ContractCommands.Update;
public class UpdateContractCommandValidator : AbstractValidator<UpdateContractCommand>
{
    public UpdateContractCommandValidator()
    {
        RuleFor(cmd => cmd.Id).NotEqual(Guid.Empty);
        RuleFor(cmd => cmd.PhoneNumber).NotEmpty();
        RuleFor(cmd => cmd.UserId).NotEqual(Guid.Empty);
        RuleFor(cmd => cmd.EmployeeId).NotEqual(Guid.Empty);
        RuleFor(cmd => cmd.TariffId).NotEqual(Guid.Empty);
    }
}
