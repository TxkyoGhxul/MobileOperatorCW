using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.TariffTypeCommands.Update;
public class UpdateTariffTypeCommandHandler : IRequestHandler<UpdateTariffTypeCommand, Unit>
{
    private readonly IFullRepository<TariffType> _repository;

    public UpdateTariffTypeCommandHandler(IFullRepository<TariffType> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(UpdateTariffTypeCommand request, CancellationToken cancellationToken)
    {
        TariffType tariffType = new TariffType
        {
            Id = request.Id,
            Name = request.Name
        };

        await _repository.UpdateAsync(tariffType, cancellationToken);

        return Unit.Value;
    }
}
