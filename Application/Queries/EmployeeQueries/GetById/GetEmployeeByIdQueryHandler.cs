using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.EmployeeQueries.GetById;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
{
    private readonly IFullRepository<Employee> _repository;

    public GetEmployeeByIdQueryHandler(IFullRepository<Employee> repository) =>
        _repository = repository;

    public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken) => 
        await _repository.SelectByIdAsync(request.Id, cancellationToken);
}
