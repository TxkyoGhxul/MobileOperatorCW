using Application.Interfaces;
using MediatR;

namespace Application.Commands.EmployeeCommands.Delete;
public record DeleteEmployeeCommand(Guid Id) : IRequest<IResponse<Unit>>;
