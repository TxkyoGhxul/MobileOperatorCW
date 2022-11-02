using Application.Common.Mappers;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.EmployeeCommands.Update;
public class UpdateEmployeeCommandHandler : 
    IRequestHandler<UpdateEmployeeCommand, IResponse<Unit>>
{
    private readonly IFullRepository<Employee> _repository;

    public UpdateEmployeeCommandHandler(IFullRepository<Employee> repository) =>
        _repository = repository;

    public async Task<IResponse<Unit>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = request.ToDomain();

        await _repository.UpdateAsync(employee, cancellationToken);

        return Unit.Value;
    }
}
