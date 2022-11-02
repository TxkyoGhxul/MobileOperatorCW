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
        return await _repository.SelectByIdAsync(request.Id, cancellationToken);
    }
}
