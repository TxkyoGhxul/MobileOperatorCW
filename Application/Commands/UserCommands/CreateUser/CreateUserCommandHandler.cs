using Application.Common.Mappers;
using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.UserCommands.CreateUser;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IResponse<Guid>>
{
	private readonly IFullRepository<User> _repository;

	public CreateUserCommandHandler(IFullRepository<User> repository) => _repository = repository;

	public async Task<IResponse<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		try
		{
			var user = request.ToDomain();

			var response = await _repository.InsertAsync(user, cancellationToken);

			return new Response<Guid>(response, Status.Created);
		}
        catch (Exception ex)
        {
            return new Response<Guid>(ex.Message, Status.NotCreated);
        }
	}
}