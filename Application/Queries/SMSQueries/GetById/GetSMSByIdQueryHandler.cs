using Application.Common.Responses;
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
        try
        {
            var response = await _repository.SelectByIdAsync(request.Id, cancellationToken);

            return new Response<SMS>(response);
        }
        catch (Exception ex)
        {
            return new Response<SMS>(ex.Message);
        }
    }
}
