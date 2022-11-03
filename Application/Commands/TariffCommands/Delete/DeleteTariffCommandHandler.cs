using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.TariffCommands.Delete;

public class DeleteTariffCommandHandler : IRequestHandler<DeleteTariffCommand, IResponse<Unit>>
{
    private readonly IFullRepository<Tariff> _repository;

    public DeleteTariffCommandHandler(IFullRepository<Tariff> repository) =>
        _repository = repository;

    public async Task<IResponse<Unit>> Handle(DeleteTariffCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.Id, cancellationToken);

            return new Response<Unit>(Unit.Value, Status.Deleted);
        }
        catch (Exception ex)
        {
            return new Response<Unit>(ex.Message, Status.NotDeleted);
        }
    }
}
