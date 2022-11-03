using Application.Common.Mappers;
using Application.Common.Responses;
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
        try
        {
            var employee = request.ToDomain();

            await _repository.UpdateAsync(employee, cancellationToken);

            return new Response<Unit>(Unit.Value, Status.Updated);
        }
        catch (Exception ex)
        {
            return new Response<Unit>(ex.Message, Status.NotUpdated);
        }
    }
}
