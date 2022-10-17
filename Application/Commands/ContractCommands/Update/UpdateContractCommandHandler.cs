using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.ContractCommands.Update;
public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand, Unit>
{
    private readonly IFullRepository<Contract> _repository;

    public UpdateContractCommandHandler(IFullRepository<Contract> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
    {
        Contract contract = new Contract
        {
            Id = request.Id,
            UserId = request.UserId,
            EmployeeId = request.EmployeeId,
            TariffId = request.TariffId,
            Date = request.Date,
            PhoneNumber = request.PhoneNumber
        };

        await _repository.UpdateAsync(contract, cancellationToken);

        return Unit.Value;
    }
}
