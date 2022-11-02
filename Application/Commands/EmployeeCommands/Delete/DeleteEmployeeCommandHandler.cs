using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.EmployeeCommands.Delete;
public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, IResponse<Unit>>
{
    private readonly IFullRepository<Employee> _repository;

    public DeleteEmployeeCommandHandler(IFullRepository<Employee> repository) =>
        _repository = repository;

    public async Task<IResponse<Unit>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.Id, cancellationToken);

            return new Response<Unit>(Unit.Value, StatusCode.Deleted);
        }
        catch (Exception ex)
        {
            return new Response<Unit>(ex.Message, StatusCode.NotDeleted);
        }
    }
}
