using Application.Common.Responses;
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
        try
        {
            var response = await _repository.SelectAllAsync(cancellationToken);

            return new Response<IEnumerable<Contract>>(response);
        }
        catch (Exception ex)
        {
            return new Response<IEnumerable<Contract>>(ex.Message);
        }
    }
}
