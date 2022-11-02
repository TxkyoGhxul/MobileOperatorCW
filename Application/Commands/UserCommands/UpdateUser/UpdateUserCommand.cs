using Application.Interfaces;
using MediatR;

namespace Application.Commands.UserCommands.UpdateUser;
public record UpdateUserCommand(Guid Id, string Name, string Surname, string MiddleName,
                            string Adress, string Passport) : IRequest<IResponse<Unit>>;
