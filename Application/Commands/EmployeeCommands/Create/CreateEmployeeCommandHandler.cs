using Application.Common.Mappers;
using Application.Common.Responses;
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
        try
        {
            var employee = request.ToDomain();

            var response = await _repository.InsertAsync(employee, cancellationToken);

            return new Response<Guid>(response, Status.Created);
        }
        catch (Exception ex)
        {
            return new Response<Guid>(ex.Message, Status.NotCreated);
        }
    }
}
