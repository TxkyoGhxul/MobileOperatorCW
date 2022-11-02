using Application.Interfaces;
using MediatR;

namespace Application.Commands.EmployeeCommands.Create;
public record CreateEmployeeCommand(string Name, string Surname, string MiddleName,
    Guid PositionId) : IRequest<IResponse<Guid>>;
