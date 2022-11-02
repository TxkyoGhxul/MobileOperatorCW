using Application.Common.Mappers;
using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.ContractCommands.Create;
public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, IResponse<Guid>>
{
    private readonly IFullRepository<Contract> _repository;

    public CreateContractCommandHandler(IFullRepository<Contract> repository) =>
        _repository = repository;

    public async Task<IResponse<Guid>> Handle(CreateContractCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var contract = request.ToDomain();

            var response = await _repository.InsertAsync(contract, cancellationToken);

            return new Response<Guid>(response, StatusCode.Created);
        }
        catch (Exception ex)
        {
            return new Response<Guid>(ex.Message, StatusCode.NotCreated);
        }
    }
}
