using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.PositionCommands.Create;

public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, Guid>
{
    private readonly IFullRepository<Position> _repository;

    public CreatePositionCommandHandler(IFullRepository<Position> repository) =>
        _repository = repository;

    public async Task<Guid> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
    {
        Position position = new Position
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Salary = request.Salary
        };

        return await _repository.InsertAsync(position, cancellationToken);
    }
}
