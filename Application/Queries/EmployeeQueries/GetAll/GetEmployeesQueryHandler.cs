using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.EmployeeQueries.GetAll;

public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<Employee>>
{
    private readonly IFullRepository<Employee> _repository;

    public GetEmployeesQueryHandler(IFullRepository<Employee> repository) =>
        _repository = repository;

    public async Task<IEnumerable<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken) => 
        await _repository.SelectAllAsync(cancellationToken);
}
