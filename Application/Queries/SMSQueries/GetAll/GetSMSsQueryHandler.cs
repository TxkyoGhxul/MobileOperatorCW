using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.SMSQueries.GetAll;

public class GetSMSsQueryHandler : IRequestHandler<GetSMSsQuery, IEnumerable<SMS>>
{
    private readonly IFullRepository<SMS> _repository;

    public GetSMSsQueryHandler(IFullRepository<SMS> repository) =>
        _repository = repository;

    public async Task<IEnumerable<SMS>> Handle(GetSMSsQuery request, CancellationToken cancellationToken) => 
        await _repository.SelectAllAsync(cancellationToken);
}
