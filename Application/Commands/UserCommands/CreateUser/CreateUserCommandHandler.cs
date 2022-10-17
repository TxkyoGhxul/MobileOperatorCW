using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.UserCommands.CreateUser;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
	private readonly IFullRepository<User> _repository;

	public CreateUserCommandHandler(IFullRepository<User> repository) => _repository = repository;

	public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		User user = new User
		{
			Id = Guid.NewGuid(),
			Name = request.Name,
			Surname = request.Surname,
			MiddleName = request.MiddleName,
			Adress = request.Adress,
			Passport = request.Passport
		};

		return await _repository.InsertAsync(user, cancellationToken);
	}
}