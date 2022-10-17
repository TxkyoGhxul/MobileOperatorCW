using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.InternetTrafficCommands.Update;

public class UpdateInternetTrafficCommandHandler :
    IRequestHandler<UpdateInternetTrafficCommand, Unit>
{
    private readonly IFullRepository<InternetTraffic> _repository;

    public UpdateInternetTrafficCommandHandler(IFullRepository<InternetTraffic> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(UpdateInternetTrafficCommand request, CancellationToken cancellationToken)
    {
        InternetTraffic traffic = new InternetTraffic
        {
            Id = request.Id,
            ContractId = request.ContractId,
            MbSpent = request.MbSpent,
            Date = request.Date
        };

        await _repository.UpdateAsync(traffic, cancellationToken);

        return Unit.Value;
    }
}
