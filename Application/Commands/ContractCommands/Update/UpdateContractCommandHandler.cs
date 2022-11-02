using Application.Common.Mappers;
using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.ContractCommands.Update;
public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand, IResponse<Unit>>
{
    private readonly IFullRepository<Contract> _repository;

    public UpdateContractCommandHandler(IFullRepository<Contract> repository) =>
        _repository = repository;

    public async Task<IResponse<Unit>> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var contract = request.ToDomain();

            await _repository.UpdateAsync(contract, cancellationToken);

            return new Response<Unit>(Unit.Value, StatusCode.Updated);
        }
        catch (Exception ex)
        {
            return new Response<Unit>(ex.Message, StatusCode.NotUpdated);
        }
    }
}
