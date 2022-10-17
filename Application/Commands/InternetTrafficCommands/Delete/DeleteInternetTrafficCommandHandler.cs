using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.InternetTrafficCommands.Delete;

public class DeleteInternetTrafficCommandHandler :
	IRequestHandler<DeleteInternetTrafficCommand, Unit>
{
    private readonly IFullRepository<InternetTraffic> _repository;

    public DeleteInternetTrafficCommandHandler(IFullRepository<InternetTraffic> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(DeleteInternetTrafficCommand request, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(request.Id, cancellationToken);

		return Unit.Value;
	}
}
