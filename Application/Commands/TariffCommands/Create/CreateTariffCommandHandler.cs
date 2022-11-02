using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.TariffCommands.Create;

public class CreateTariffCommandHandler : IRequestHandler<CreateTariffCommand, IResponse<Guid>>
{
    private readonly IFullRepository<Tariff> _repository;

    public CreateTariffCommandHandler(IFullRepository<Tariff> repository) =>
        _repository = repository;

    public async Task<IResponse<Guid>> Handle(CreateTariffCommand request, CancellationToken cancellationToken)
    {
        Tariff tariff = new Tariff
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Cost = request.Cost,
            LocalCost = request.LocalCost,
            TownCost = request.TownCost,
            CountryCost = request.CountryCost,
            SMSCost = request.SMSCost,
            MbCost = request.MbCost,
            TariffTypeId = request.TariffTypeId
        };

        return await _repository.InsertAsync(tariff, cancellationToken);
    }
}
