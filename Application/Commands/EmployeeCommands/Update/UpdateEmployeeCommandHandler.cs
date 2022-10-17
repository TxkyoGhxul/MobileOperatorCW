using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.EmployeeCommands.Update;
public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
{
    private readonly IFullRepository<Employee> _repository;

    public UpdateEmployeeCommandHandler(IFullRepository<Employee> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        Employee employee = new Employee
        {
            Id = request.Id,
            Name = request.Name,
            Surname = request.Surname,
            MiddleName = request.MiddleName,
            PositionId = request.PositionId
        };

        await _repository.UpdateAsync(employee, cancellationToken);

        return Unit.Value;
    }
}
