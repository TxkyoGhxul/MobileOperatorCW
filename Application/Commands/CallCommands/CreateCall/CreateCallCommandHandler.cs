using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.CallCommands.CreateCall;

public class CreateCallCommandHandler : IRequestHandler<CreateCallCommand, Guid>
{
    private readonly IFullRepository<Call> _repository;

    public CreateCallCommandHandler(IFullRepository<Call> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateCallCommand request, CancellationToken cancellationToken)
    {
        var call = new Call
        {
            Id = Guid.NewGuid(),
            Contract = request.Contract,
            Date = request.Date,
            TimeSpan = request.TimeSpan
        };

        return await _repository.InsertAsync(call, cancellationToken);
    }
}
