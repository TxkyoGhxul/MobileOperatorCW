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
        return await _repository.SelectAllAsync(cancellationToken);
    }
}
