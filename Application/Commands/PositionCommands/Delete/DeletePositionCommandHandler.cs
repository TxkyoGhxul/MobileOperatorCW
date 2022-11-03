using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.PositionCommands.Delete;

public class DeletePositionCommandHandler : 
    IRequestHandler<DeletePositionCommand, IResponse<Unit>>
{
    private readonly IFullRepository<Position> _repository;

    public DeletePositionCommandHandler(IFullRepository<Position> repository) =>
        _repository = repository;

    public async Task<IResponse<Unit>> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.Id, cancellationToken);

            return new Response<Unit>(Unit.Value, Status.Deleted);
        }
        catch (Exception ex)
        {
            return new Response<Unit>(ex.Message, Status.NotDeleted);
        }
    }
}