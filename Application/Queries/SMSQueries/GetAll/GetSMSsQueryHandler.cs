using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.SMSQueries.GetAll;

public class GetSMSsQueryHandler : IRequestHandler<GetSMSsQuery, IResponse<IEnumerable<SMS>>>
{
    private readonly IFullRepository<SMS> _repository;

    public GetSMSsQueryHandler(IFullRepository<SMS> repository) =>
        _repository = repository;

    public async Task<IResponse<IEnumerable<SMS>>> Handle(GetSMSsQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.SelectAllAsync(cancellationToken);
    }
}
