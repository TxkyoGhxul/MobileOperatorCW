using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.TariffQueries.GetById;

public class GetTariffByIdQueryHandler : IRequestHandler<GetTariffByIdQuery, Tariff>
{
    private readonly IFullRepository<Tariff> _repository;

    public GetTariffByIdQueryHandler(IFullRepository<Tariff> repository) =>
        _repository = repository;

    public async Task<Tariff> Handle(GetTariffByIdQuery request, CancellationToken cancellationToken) => 
        await _repository.SelectByIdAsync(request.Id, cancellationToken);
}
