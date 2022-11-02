using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.TariffTypeQueries.GetAll;
public class GetTariffTypesQueryHandler : 
    IRequestHandler<GetTariffTypesQuery, IResponse<IEnumerable<TariffType>>>
{
    private readonly IFullRepository<TariffType> _repository;

    public GetTariffTypesQueryHandler(IFullRepository<TariffType> repository) => 
        _repository = repository;

    public async Task<IResponse<IEnumerable<TariffType>>> Handle(GetTariffTypesQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.SelectAllAsync(cancellationToken);
    }
}
