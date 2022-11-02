using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.TariffTypeQueries.GetById;
public class GetTariffTypeByIdQueryHandler : 
    IRequestHandler<GetTariffTypeByIdQuery, IResponse<TariffType>>
{
    private readonly IFullRepository<TariffType> _repository;

    public GetTariffTypeByIdQueryHandler(IFullRepository<TariffType> repository) => 
        _repository = repository;

    public async Task<IResponse<TariffType>> Handle(GetTariffTypeByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.SelectByIdAsync(request.Id, cancellationToken);
    }
}
