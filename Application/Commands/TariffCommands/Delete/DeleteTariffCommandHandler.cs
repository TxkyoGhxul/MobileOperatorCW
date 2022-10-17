using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.TariffCommands.Delete;

public class DeleteTariffCommandHandler : IRequestHandler<DeleteTariffCommand, Unit>
{
    private readonly IFullRepository<Tariff> _repository;

    public DeleteTariffCommandHandler(IFullRepository<Tariff> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(DeleteTariffCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id, cancellationToken);

        return Unit.Value;
    }
}
