using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.ContractQueries.GetAll;

public class GetContractsQueryHandler : IRequestHandler<GetContractsQuery, IEnumerable<Contract>>
{
    private readonly IFullRepository<Contract> _repository;

    public GetContractsQueryHandler(IFullRepository<Contract> repository) => 
        _repository = repository;

    public async Task<IEnumerable<Contract>> Handle(GetContractsQuery request, CancellationToken cancellationToken) => 
        await _repository.SelectAllAsync(cancellationToken);
}
