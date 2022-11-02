using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.ContractQueries.GetAll;

public class GetContractsQueryHandler : 
    IRequestHandler<GetContractsQuery, IResponse<IEnumerable<Contract>>>
{
    private readonly IFullRepository<Contract> _repository;

    public GetContractsQueryHandler(IFullRepository<Contract> repository) => 
        _repository = repository;

    public async Task<IResponse<IEnumerable<Contract>>> Handle(GetContractsQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.SelectAllAsync(cancellationToken);
    }
}
