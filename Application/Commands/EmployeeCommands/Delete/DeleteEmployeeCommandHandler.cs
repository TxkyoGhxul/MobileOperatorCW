using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.EmployeeCommands.Delete;
public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
{
    private readonly IFullRepository<Employee> _repository;

    public DeleteEmployeeCommandHandler(IFullRepository<Employee> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id, cancellationToken);

        return Unit.Value;
    }
}
