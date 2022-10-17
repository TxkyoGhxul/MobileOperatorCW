using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.SMSCommands.Update;

public class UpdateSMSCommandHandler : IRequestHandler<UpdateSMSCommand, Unit>
{
    private readonly IFullRepository<SMS> _repository;

    public UpdateSMSCommandHandler(IFullRepository<SMS> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(UpdateSMSCommand request, CancellationToken cancellationToken)
    {
        SMS sms = new SMS
        {
            Id = request.Id,
            Message = request.Message,
            ContractId = request.ContractId
        };

        await _repository.UpdateAsync(sms, cancellationToken);

        return Unit.Value;
    }
}
