using Application.Common.Mappers;
using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.PositionCommands.Create;

public class CreatePositionCommandHandler : 
    IRequestHandler<CreatePositionCommand, IResponse<Guid>>
{
    private readonly IFullRepository<Position> _repository;

    public CreatePositionCommandHandler(IFullRepository<Position> repository) =>
        _repository = repository;

    public async Task<IResponse<Guid>> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var position = request.ToDomain();

            var response = await _repository.InsertAsync(position, cancellationToken);

            return new Response<Guid>(response, StatusCode.Created);
        }
        catch (Exception ex)
        {
            return new Response<Guid>(ex.Message, StatusCode.NotCreated);
        }
    }
}
