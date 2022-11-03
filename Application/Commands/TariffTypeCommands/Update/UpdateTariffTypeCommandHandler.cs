using Application.Common.Mappers;
using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.TariffTypeCommands.Update;
public class UpdateTariffTypeCommandHandler : 
    IRequestHandler<UpdateTariffTypeCommand, IResponse<Unit>>
{
    private readonly IFullRepository<TariffType> _repository;

    public UpdateTariffTypeCommandHandler(IFullRepository<TariffType> repository) =>
        _repository = repository;

    public async Task<IResponse<Unit>> Handle(UpdateTariffTypeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var tariffType = request.ToDomain();

            await _repository.UpdateAsync(tariffType, cancellationToken);

            return new Response<Unit>(Unit.Value, Status.Updated);
        }
        catch (Exception ex)
        {
            return new Response<Unit>(ex.Message, Status.NotUpdated);
        }
    }
}
