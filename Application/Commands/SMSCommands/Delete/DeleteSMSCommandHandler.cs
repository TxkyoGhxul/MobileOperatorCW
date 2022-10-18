﻿using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.SMSCommands.Delete;

public class DeleteSMSCommandHandler : IRequestHandler<DeleteSMSCommand, Unit>
{
    private readonly IFullRepository<SMS> _repository;

    public DeleteSMSCommandHandler(IFullRepository<SMS> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(DeleteSMSCommand request, CancellationToken cancellationToken)
	{
        await _repository.DeleteAsync(request.Id, cancellationToken);

        return Unit.Value;
	}
}