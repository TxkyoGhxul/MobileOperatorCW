using FluentValidation;

namespace Application.Commands.ContractCommands.Delete;
public class DeleteContractCommandValidator : AbstractValidator<DeleteContractCommand>
{
    public DeleteContractCommandValidator() => RuleFor(cmd => cmd.Id).NotEqual(Guid.Empty);
}
