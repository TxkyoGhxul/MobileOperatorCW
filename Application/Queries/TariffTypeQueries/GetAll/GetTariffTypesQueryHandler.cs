using Application.Common.Responses;
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
        try
        {
            var response = await _repository.SelectAllAsync(cancellationToken);

            return new Response<IEnumerable<TariffType>>(response);
        }
        catch (Exception ex)
        {
            return new Response<IEnumerable<TariffType>>(ex.Message);
        }
    }
}
