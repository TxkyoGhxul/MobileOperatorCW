using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.ContractCommands.Create;
public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, Guid>
{
    private readonly IFullRepository<Contract> _repository;

    public CreateContractCommandHandler(IFullRepository<Contract> repository) =>
        _repository = repository;

    public async Task<Guid> Handle(CreateContractCommand request, CancellationToken cancellationToken)
    {
        Contract contract = new Contract
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            EmployeeId = request.EmployeeId,
            TariffId = request.TariffId,
            Date = request.Date,
            PhoneNumber = request.PhoneNumber
        };

        return await _repository.InsertAsync(contract, cancellationToken);
    }
}
