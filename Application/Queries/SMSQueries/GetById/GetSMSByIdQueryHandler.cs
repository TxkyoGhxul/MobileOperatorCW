using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.SMSQueries.GetById;

public class GetSMSByIdQueryHandler : IRequestHandler<GetSMSByIdQuery, SMS>
{
    private readonly IFullRepository<SMS> _repository;

    public GetSMSByIdQueryHandler(IFullRepository<SMS> repository) =>
        _repository = repository;

    public async Task<SMS> Handle(GetSMSByIdQuery request, CancellationToken cancellationToken) =>
        await _repository.SelectByIdAsync(request.Id, cancellationToken);
}
