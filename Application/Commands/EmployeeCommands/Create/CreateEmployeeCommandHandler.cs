using Application.Common.Mappers;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.EmployeeCommands.Create;

public class CreateEmployeeCommandHandler : 
    IRequestHandler<CreateEmployeeCommand, IResponse<Guid>>
{
    private readonly IFullRepository<Employee> _repository;

    public CreateEmployeeCommandHandler(IFullRepository<Employee> repository) => 
        _repository = repository;

    public async Task<IResponse<Guid>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = request.ToDomain();

        return await _repository.InsertAsync(employee, cancellationToken);
    }
}
