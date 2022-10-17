using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.ContractCommands.Delete;
public class DeleteContractCommandHandler : IRequestHandler<DeleteContractCommand, Unit>
{
    private readonly IFullRepository<Contract> _repository;

    public DeleteContractCommandHandler(IFullRepository<Contract> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
