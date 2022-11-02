using Application.Common.Mappers;
using Application.Common.Responses;
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
        try
        {
            var tariff = request.ToDomain();

            var response = await _repository.InsertAsync(tariff, cancellationToken);

            return new Response<Guid>(response, StatusCode.Created);
        }
        catch (Exception ex)
        {
            return new Response<Guid>(ex.Message, StatusCode.NotCreated);
        }
    }
}
