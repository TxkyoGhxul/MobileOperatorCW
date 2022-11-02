using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.TariffQueries.GetById;

public class GetTariffByIdQueryHandler : IRequestHandler<GetTariffByIdQuery, IResponse<Tariff>>
{
    private readonly IFullRepository<Tariff> _repository;

    public GetTariffByIdQueryHandler(IFullRepository<Tariff> repository) =>
        _repository = repository;

    public async Task<IResponse<Tariff>> Handle(GetTariffByIdQuery request, CancellationToken ct)
    {
        return await _repository.SelectByIdAsync(request.Id, ct);
    }
}
