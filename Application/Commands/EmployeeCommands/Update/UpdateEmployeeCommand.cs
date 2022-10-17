using MediatR;

namespace Application.Commands.EmployeeCommands.Update;
public record UpdateEmployeeCommand(Guid Id, string Name, string Surname, 
    string MiddleName, Guid PositionId) : IRequest;