using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.TariffQueries.GetAll;

public class GetTariffsQueryHandler : 
    IRequestHandler<GetTariffsQuery, IResponse<IEnumerable<Tariff>>>
{
    private readonly IFullRepository<Tariff> _repository;

    public GetTariffsQueryHandler(IFullRepository<Tariff> repository) =>
        _repository = repository;

    public async Task<IResponse<IEnumerable<Tariff>>> Handle(GetTariffsQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.SelectAllAsync(cancellationToken);
    }
}
