using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.EmployeeCommands.Create;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IFullRepository<Employee> _repository;

    public CreateEmployeeCommandHandler(IFullRepository<Employee> repository) => 
        _repository = repository;

    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        Employee employee = new Employee
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Surname = request.Surname,
            MiddleName = request.MiddleName,
            PositionId = request.PositionId
        };

        return await _repository.InsertAsync(employee, cancellationToken);
    }
}
