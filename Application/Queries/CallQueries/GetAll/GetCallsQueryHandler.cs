using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.CallQueries.GetAll;

public class GetCallsQueryHandler : IRequestHandler<GetCallsQuery, IResponse<IEnumerable<Call>>>
{
    private readonly IFullRepository<Call> _repository;

    public GetCallsQueryHandler(IFullRepository<Call> repository) =>
        _repository = repository;

    public async Task<IResponse<IEnumerable<Call>>> Handle(GetCallsQuery request, 
        CancellationToken ct)
    {
        try
        {
            var response = await _repository.SelectAllAsync(ct);

            return new Response<IEnumerable<Call>>(response);
        }
        catch (Exception ex)
        {
            return new Response<IEnumerable<Call>>(ex.Message);
        }
    }
}
