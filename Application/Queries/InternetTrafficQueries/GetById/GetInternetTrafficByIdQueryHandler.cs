using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.InternetTrafficQueries.GetById;

public class GetInternetTrafficByIdQueryHandler : 
    IRequestHandler<GetInternetTrafficByIdQuery, IResponse<InternetTraffic>>
{
    private readonly IFullRepository<InternetTraffic> _repository;

    public GetInternetTrafficByIdQueryHandler(IFullRepository<InternetTraffic> repository) =>
        _repository = repository;

    public async Task<IResponse<InternetTraffic>> Handle(
        GetInternetTrafficByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.SelectByIdAsync(request.Id, cancellationToken);
    }
}
