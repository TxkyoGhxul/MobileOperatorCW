using Application.Common.Mappers;
using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.CallCommands.UpdateCall;

public class UpdateCallCommandHandler : IRequestHandler<UpdateCallCommand, IResponse<Unit>>
{
    private readonly IFullRepository<Call> _repository;

    public UpdateCallCommandHandler(IFullRepository<Call> repository) => _repository = repository;

    public async Task<IResponse<Unit>> Handle(UpdateCallCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var call = request.ToDomain();

            await _repository.UpdateAsync(call, cancellationToken);

            return new Response<Unit>(Unit.Value, StatusCode.Updated);
        }
        catch (Exception ex)
        {
            return new Response<Unit>(ex.Message, StatusCode.NotUpdated);
        }
    }
}
