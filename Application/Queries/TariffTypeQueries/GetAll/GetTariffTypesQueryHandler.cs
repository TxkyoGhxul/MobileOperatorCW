using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.TariffTypeQueries.GetAll;
public class GetTariffTypesQueryHandler : IRequestHandler<GetTariffTypesQuery, IEnumerable<TariffType>>
{
    private readonly IFullRepository<TariffType> _repository;

    public GetTariffTypesQueryHandler(IFullRepository<TariffType> repository) => 
        _repository = repository;

    public async Task<IEnumerable<TariffType>> Handle(GetTariffTypesQuery request, CancellationToken cancellationToken) => 
        await _repository.SelectAllAsync(cancellationToken);
}
