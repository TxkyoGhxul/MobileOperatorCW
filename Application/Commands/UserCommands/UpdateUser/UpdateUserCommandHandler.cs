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
        User user = new User
        {
            Id = request.Id,
            Name = request.Name,
            Surname = request.Surname,
            MiddleName = request.MiddleName,
            Adress = request.Adress,
            Passport = request.Passport
        };

        await _repository.UpdateAsync(user, cancellationToken);

        return Unit.Value;
    }
}
