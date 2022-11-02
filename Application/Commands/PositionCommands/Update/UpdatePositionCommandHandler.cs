using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.PositionCommands.Update;

public class UpdatePositionCommandHandler : 
    IRequestHandler<UpdatePositionCommand, IResponse<Unit>>
{
    private readonly IFullRepository<Position> _repository;

    public UpdatePositionCommandHandler(IFullRepository<Position> repository) =>
        _repository = repository;

    public async Task<IResponse<Unit>> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
    {
        Position position = new Position
        {
            Id = request.Id,
            Name = request.Name,
            Salary = request.Salarys
        };

        await _repository.UpdateAsync(position, cancellationToken);

        return Unit.Value;
    }
}
