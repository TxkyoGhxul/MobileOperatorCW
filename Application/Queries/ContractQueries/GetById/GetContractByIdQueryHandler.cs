using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.ContractQueries.GetById;

public class GetContractByIdQueryHandler : 
    IRequestHandler<GetContractByIdQuery, IResponse<Contract>>
{
    private readonly IFullRepository<Contract> _repository;

    public GetContractByIdQueryHandler(IFullRepository<Contract> repository) =>
        _repository = repository;

    public async Task<IResponse<Contract>> Handle(GetContractByIdQuery request, 
        CancellationToken cancellationToken)
    {
        return await _repository.SelectByIdAsync(request.Id, cancellationToken);
    }
}
