using Application.Common.Mappers;
using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.CallCommands.CreateCall;

public class CreateCallCommandHandler : IRequestHandler<CreateCallCommand, IResponse<Guid>>
{
    private readonly IFullRepository<Call> _repository;

    public CreateCallCommandHandler(IFullRepository<Call> repository) => _repository = repository;

    public async Task<IResponse<Guid>> Handle(CreateCallCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var call = request.ToDomain();

            var response = await _repository.InsertAsync(call, cancellationToken);

            return new Response<Guid>(response, Status.Created);
        }
        catch (Exception ex)
        {
            return new Response<Guid>(ex.Message, Status.NotCreated);
        }
    }
}
