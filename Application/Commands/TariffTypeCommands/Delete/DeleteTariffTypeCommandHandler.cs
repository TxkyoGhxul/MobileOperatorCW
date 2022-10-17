using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.TariffTypeCommands.Delete;
public class DeleteTariffTypeCommandHandler : IRequestHandler<DeleteTariffTypeCommand, Unit>
{
    private readonly IFullRepository<TariffType> _repository;

    public DeleteTariffTypeCommandHandler(IFullRepository<TariffType> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(DeleteTariffTypeCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id, cancellationToken);

        return Unit.Value;
    }
}
