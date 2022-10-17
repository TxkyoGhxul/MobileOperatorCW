using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.CallCommands.UpdateCall;

public class UpdateCallCommandHandler : IRequestHandler<UpdateCallCommand, Unit>
{
    private readonly IFullRepository<Call> _repository;

    public UpdateCallCommandHandler(IFullRepository<Call> repository) => _repository = repository;

    public async Task<Unit> Handle(UpdateCallCommand request, CancellationToken cancellationToken)
    {
        var call = new Call
        {
            Id = request.Id,
            Contract = request.Contract,
            Date = request.Date,
            TimeSpan = request.TimeSpan
        };

        await _repository.UpdateAsync(call, cancellationToken);

        return Unit.Value;
    }
}
