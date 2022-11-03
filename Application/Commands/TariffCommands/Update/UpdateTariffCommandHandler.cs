using Application.Common.Mappers;
using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.TariffCommands.Update;

public class UpdateTariffCommandHandler : IRequestHandler<UpdateTariffCommand, IResponse<Unit>>
{
    private readonly IFullRepository<Tariff> _repository;

    public UpdateTariffCommandHandler(IFullRepository<Tariff> repository) =>
        _repository = repository;

    public async Task<IResponse<Unit>> Handle(UpdateTariffCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var tariff = request.ToDomain();

            await _repository.UpdateAsync(tariff, cancellationToken);

            return new Response<Unit>(Unit.Value, Status.Updated);
        }
        catch (Exception ex)
        {
            return new Response<Unit>(ex.Message, Status.NotUpdated);
        }
    }
}
