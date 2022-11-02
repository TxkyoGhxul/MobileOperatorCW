using Application.Interfaces;
using MediatR;

namespace Application.Commands.UserCommands.CreateUser;
public record CreateUserCommand(string Name, string Surname, string MiddleName, 
                            string Adress, string Passport) : IRequest<IResponse<Guid>>;
