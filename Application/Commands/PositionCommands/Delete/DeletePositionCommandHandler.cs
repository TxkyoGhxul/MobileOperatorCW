using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.PositionCommands.Delete;

public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand, Unit>
{
    private readonly IFullRepository<Position> _repository;

    public DeletePositionCommandHandler(IFullRepository<Position> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id, cancellationToken);

        return Unit.Value;
    }
}