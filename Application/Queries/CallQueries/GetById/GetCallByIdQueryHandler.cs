using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.CallQueries.GetById;

public class GetCallByIdQueryHandler : IRequestHandler<GetCallByIdQuery, IResponse<Call>>
{
    private readonly IFullRepository<Call> _repository;

    public GetCallByIdQueryHandler(IFullRepository<Call> repository) =>
        _repository = repository;

    public async Task<IResponse<Call>> Handle(GetCallByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _repository.SelectByIdAsync(request.Id, cancellationToken);

            return new Response<Call>(response);
        }
        catch (Exception ex)
        {
            return new Response<Call>(ex.Message);
        }
    }
}
