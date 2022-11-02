using Application.Common.Mappers;
using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.SMSCommands.Update;

public class UpdateSMSCommandHandler : IRequestHandler<UpdateSMSCommand, IResponse<Unit>>
{
    private readonly IFullRepository<SMS> _repository;

    public UpdateSMSCommandHandler(IFullRepository<SMS> repository) =>
        _repository = repository;

    public async Task<IResponse<Unit>> Handle(UpdateSMSCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var sms = request.ToDomain();

            await _repository.UpdateAsync(sms, cancellationToken);

            return new Response<Unit>(Unit.Value, StatusCode.Updated);
        }
        catch (Exception ex)
        {
            return new Response<Unit>(ex.Message, StatusCode.NotUpdated);
        }
    }
}
