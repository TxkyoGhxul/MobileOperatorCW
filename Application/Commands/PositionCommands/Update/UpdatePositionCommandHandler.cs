using Application.Common.Mappers;
using Application.Common.Responses;
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
        try
        {
            var position = request.ToDomain();

            await _repository.UpdateAsync(position, cancellationToken);

            return new Response<Unit>(Unit.Value, StatusCode.Updated);
        }
        catch (Exception ex)
        {
            return new Response<Unit>(ex.Message, StatusCode.NotUpdated);
        }
    }
}
