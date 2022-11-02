using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.CallCommands.DeleteCall;

public class DeleteCallCommandHandler : IRequestHandler<DeleteCallCommand, IResponse<Unit>>
{
    private readonly IFullRepository<Call> _repository;

    public DeleteCallCommandHandler(IFullRepository<Call> repository) => _repository = repository;

    public async Task<IResponse<Unit>> Handle(DeleteCallCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.Id, cancellationToken);

            return new Response<Unit>(Unit.Value, StatusCode.Deleted);
        }
        catch (Exception ex)
        {
            return new Response<Unit>(ex.Message, StatusCode.NotDeleted);
        }
    }
}