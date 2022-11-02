using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.EmployeeQueries.GetAll;

public class GetEmployeesQueryHandler : 
    IRequestHandler<GetEmployeesQuery, IResponse<IEnumerable<Employee>>>
{
    private readonly IFullRepository<Employee> _repository;

    public GetEmployeesQueryHandler(IFullRepository<Employee> repository) =>
        _repository = repository;

    public async Task<IResponse<IEnumerable<Employee>>> Handle(GetEmployeesQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _repository.SelectAllAsync(cancellationToken);

            return new Response<IEnumerable<Employee>>(response);
        }
        catch (Exception ex)
        {
            return new Response<IEnumerable<Employee>>(ex.Message);
        }
    }
}
