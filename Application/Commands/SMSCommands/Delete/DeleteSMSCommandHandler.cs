using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.SMSCommands.Delete;

public class DeleteSMSCommandHandler : IRequestHandler<DeleteSMSCommand, IResponse<Unit>>
{
    private readonly IFullRepository<SMS> _repository;

    public DeleteSMSCommandHandler(IFullRepository<SMS> repository) =>
        _repository = repository;

    public async Task<IResponse<Unit>> Handle(DeleteSMSCommand request, CancellationToken cancellationToken)
	{
        try
        {
            await _repository.DeleteAsync(request.Id, cancellationToken);

            return new Response<Unit>(Unit.Value, Status.Deleted);
        }
        catch (Exception ex)
        {
            return new Response<Unit>(ex.Message, Status.NotDeleted);
        }
	}
}
