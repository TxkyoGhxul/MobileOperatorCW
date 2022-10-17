using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.CallCommands.DeleteCall;

public class DeleteCallCommandHandler : IRequestHandler<DeleteCallCommand, Unit>
{
    private readonly IFullRepository<Call> _repository;

    public DeleteCallCommandHandler(IFullRepository<Call> repository) => _repository = repository;

    public async Task<Unit> Handle(DeleteCallCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id, cancellationToken);

        return Unit.Value;
    }
}