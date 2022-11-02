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
        return await _repository.SelectAllAsync(cancellationToken);
    }
}
