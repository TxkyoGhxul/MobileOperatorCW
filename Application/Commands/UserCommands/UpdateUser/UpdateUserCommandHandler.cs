using Application.Common.Mappers;
using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.UserCommands.UpdateUser;
public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, IResponse<Unit>>
{
    private readonly IFullRepository<User> _repository;

    public UpdateUserCommandHandler(IFullRepository<User> repository) => _repository = repository;

    public async Task<IResponse<Unit>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = request.ToDomain();

            await _repository.UpdateAsync(user, cancellationToken);

            return new Response<Unit>(Unit.Value, Status.Updated);
        }
        catch (Exception ex)
        {
            return new Response<Unit>(ex.Message, Status.NotUpdated);
        }
    }
}
