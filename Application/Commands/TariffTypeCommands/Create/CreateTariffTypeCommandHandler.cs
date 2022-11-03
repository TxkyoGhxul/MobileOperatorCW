using Application.Common.Mappers;
using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.TariffTypeCommands.Create;
public class CreateTariffTypeCommandHandler : 
    IRequestHandler<CreateTariffTypeCommand, IResponse<Guid>>
{
    private readonly IFullRepository<TariffType> _repository;

    public CreateTariffTypeCommandHandler(IFullRepository<TariffType> repository) =>
        _repository = repository;

    public async Task<IResponse<Guid>> Handle(CreateTariffTypeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var tariffType = request.ToDomain();

            var response = await _repository.InsertAsync(tariffType, cancellationToken);

            return new Response<Guid>(response, Status.Created);
        }
        catch (Exception ex)
        {
            return new Response<Guid>(ex.Message, Status.NotCreated);
        }
    }
}
