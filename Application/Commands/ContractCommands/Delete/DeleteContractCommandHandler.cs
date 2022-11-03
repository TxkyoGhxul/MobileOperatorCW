using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.ContractCommands.Delete;
public class DeleteContractCommandHandler : IRequestHandler<DeleteContractCommand, IResponse<Unit>>
{
    private readonly IFullRepository<Contract> _repository;

    public DeleteContractCommandHandler(IFullRepository<Contract> repository) =>
        _repository = repository;

    public async Task<IResponse<Unit>> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
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
