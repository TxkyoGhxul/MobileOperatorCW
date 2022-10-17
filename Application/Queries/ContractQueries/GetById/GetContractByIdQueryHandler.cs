using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.ContractQueries.GetById;

public class GetContractByIdQueryHandler : IRequestHandler<GetContractByIdQuery, Contract>
{
    private readonly IFullRepository<Contract> _repository;

    public GetContractByIdQueryHandler(IFullRepository<Contract> repository) =>
        _repository = repository;

    public async Task<Contract> Handle(GetContractByIdQuery request, CancellationToken cancellationToken) => 
        await _repository.SelectByIdAsync(request.Id, cancellationToken);
}
