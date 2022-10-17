using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.TariffQueries.GetAll;

public class GetTariffsQueryHandler : IRequestHandler<GetTariffsQuery, IEnumerable<Tariff>>
{
    private readonly IFullRepository<Tariff> _repository;

    public GetTariffsQueryHandler(IFullRepository<Tariff> repository) =>
        _repository = repository;

    public async Task<IEnumerable<Tariff>> Handle(GetTariffsQuery request, CancellationToken cancellationToken) => 
        await _repository.SelectAllAsync(cancellationToken);
}
