using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.UserCommands.DeleteUser;
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, IResponse<Unit>>
{
    private readonly IFullRepository<User> _repository;

    public DeleteUserCommandHandler(IFullRepository<User> repository) => _repository = repository;

    public async Task<IResponse<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
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
