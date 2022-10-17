using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.InternetTrafficCommands.Create;

public class CreateInternetTrafficCommandHandler : 
    IRequestHandler<CreateInternetTrafficCommand, Guid>
{
    private readonly IFullRepository<InternetTraffic> _repository;

    public CreateInternetTrafficCommandHandler(IFullRepository<InternetTraffic> repository) =>
        _repository = repository;

    public async Task<Guid> Handle(CreateInternetTrafficCommand request, CancellationToken cancellationToken)
    {
        InternetTraffic traffic = new InternetTraffic
        {
            Id = Guid.NewGuid(),
            ContractId = request.ContractId,
            MbSpent = request.MbSpent,
            Date = request.Date
        };

        return await _repository.InsertAsync(traffic, cancellationToken);
    }
}
