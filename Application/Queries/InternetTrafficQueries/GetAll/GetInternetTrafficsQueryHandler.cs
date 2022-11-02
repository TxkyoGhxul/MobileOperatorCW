using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.InternetTrafficQueries.GetAll;

public class GetInternetTrafficsQueryHandler :
    IRequestHandler<GetInternetTrafficsQuery, IResponse<IEnumerable<InternetTraffic>>>
{
    private readonly IFullRepository<InternetTraffic> _repository;

    public GetInternetTrafficsQueryHandler(IFullRepository<InternetTraffic> repository) => 
        _repository = repository;

    public async Task<IResponse<IEnumerable<InternetTraffic>>> Handle(
        GetInternetTrafficsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _repository.SelectAllAsync(cancellationToken);

            return new Response<IEnumerable<InternetTraffic>>(response);
        }
        catch (Exception ex)
        {
            return new Response<IEnumerable<InternetTraffic>>(ex.Message);
        }
    }
}
