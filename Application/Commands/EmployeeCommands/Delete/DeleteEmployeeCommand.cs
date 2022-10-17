using MediatR;

namespace Application.Commands.EmployeeCommands.Delete;
public record DeleteEmployeeCommand(Guid Id) : IRequest;
