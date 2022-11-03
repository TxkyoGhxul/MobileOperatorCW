using Application.Common.Mappers;
using Application.Common.Responses;
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
        try
        {
            var sms = request.ToDomain();

            var response = await _repository.InsertAsync(sms, cancellationToken);

            return new Response<Guid>(response, Status.Created);
        }
        catch (Exception ex)
        {
            return new Response<Guid>(ex.Message, Status.NotCreated);
        }
    }
}
