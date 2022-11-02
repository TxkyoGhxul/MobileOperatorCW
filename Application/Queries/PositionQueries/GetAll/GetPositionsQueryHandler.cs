using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.PositionQueries.GetAll;

public class GetPositionsQueryHandler : 
    IRequestHandler<GetPositionsQuery, IResponse<IEnumerable<Position>>>
{
    private readonly IFullRepository<Position> _repository;

    public GetPositionsQueryHandler(IFullRepository<Position> repository) =>
        _repository = repository;

    public async Task<IResponse<IEnumerable<Position>>> Handle(GetPositionsQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _repository.SelectAllAsync(cancellationToken);

            return new Response<IEnumerable<Position>>(response);
        }
        catch (Exception ex)
        {
            return new Response<IEnumerable<Position>>(ex.Message);
        }
    }
}
