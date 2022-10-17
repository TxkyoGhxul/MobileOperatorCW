using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.TariffCommands.Update;

public class UpdateTariffCommandHandler : IRequestHandler<UpdateTariffCommand, Unit>
{
    private readonly IFullRepository<Tariff> _repository;

    public UpdateTariffCommandHandler(IFullRepository<Tariff> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(UpdateTariffCommand request, CancellationToken cancellationToken)
    {
        Tariff tariff = new Tariff
        {
            Id = request.Id,
            Name = request.Name,
            Cost = request.Cost,
            LocalCost = request.LocalCost,
            TownCost = request.TownCost,
            CountryCost = request.CountryCost,
            SMSCost = request.SMSCost,
            MbCost = request.MbCost,
            TariffTypeId = request.TariffTypeId
        };

        await _repository.UpdateAsync(tariff, cancellationToken);

        return Unit.Value;
    }
}
