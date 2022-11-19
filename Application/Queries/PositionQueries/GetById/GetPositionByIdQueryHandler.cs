using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using Domain.Base;
using MediatR;

namespace Application.Queries.PositionQueries.GetById;
public class GetPositionByIdQueryHandler : 
    IRequestHandler<GetPositionByIdQuery, IResponse<Position>>
{
    private readonly IFullRepository<Position> _repository;

    public GetPositionByIdQueryHandler(IFullRepository<Position> repository) =>
        _repository = repository;

    public async Task<IResponse<Position>> Handle(GetPositionByIdQuery request, 
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _repository.SelectByIdAsync(request.Id, cancellationToken);

            return new Response<Position>(response);
        }
        catch (Exception ex)
        {
            return new Response<Position>(ex.Message);
        }
    }
}
