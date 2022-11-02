using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.SMSCommands.Create;

public class CreateSMSCommandHandler : IRequestHandler<CreateSMSCommand, IResponse<Guid>>
{
    private readonly IFullRepository<SMS> _repository;

    public CreateSMSCommandHandler(IFullRepository<SMS> repository) =>
        _repository = repository;

    public async Task<IResponse<Guid>> Handle(CreateSMSCommand request, CancellationToken cancellationToken)
    {
        SMS sms = new SMS
        {
            Id = Guid.NewGuid(),
            Message = request.Message,
            ContractId = request.ContractId
        };

        return await _repository.InsertAsync(sms, cancellationToken);
    }
}
