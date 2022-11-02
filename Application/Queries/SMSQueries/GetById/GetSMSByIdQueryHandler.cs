using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.SMSQueries.GetById;

public class GetSMSByIdQueryHandler : IRequestHandler<GetSMSByIdQuery, IResponse<SMS>>
{
    private readonly IFullRepository<SMS> _repository;

    public GetSMSByIdQueryHandler(IFullRepository<SMS> repository) =>
        _repository = repository;

    public async Task<IResponse<SMS>> Handle(GetSMSByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.SelectByIdAsync(request.Id, cancellationToken);
    }
}
