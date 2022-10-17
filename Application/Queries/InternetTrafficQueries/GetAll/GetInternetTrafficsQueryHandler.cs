using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.InternetTrafficQueries.GetAll;

public class GetInternetTrafficsQueryHandler :
    IRequestHandler<GetInternetTrafficsQuery, IEnumerable<InternetTraffic>>
{
    private readonly IFullRepository<InternetTraffic> _repository;

    public GetInternetTrafficsQueryHandler(IFullRepository<InternetTraffic> repository) => 
        _repository = repository;

    public async Task<IEnumerable<InternetTraffic>> Handle(GetInternetTrafficsQuery request, CancellationToken cancellationToken) => 
        await _repository.SelectAllAsync(cancellationToken);
}
