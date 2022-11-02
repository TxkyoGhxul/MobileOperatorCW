using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.EmployeeQueries.GetById;

public class GetEmployeeByIdQueryHandler : 
    IRequestHandler<GetEmployeeByIdQuery, IResponse<Employee>>
{
    private readonly IFullRepository<Employee> _repository;

    public GetEmployeeByIdQueryHandler(IFullRepository<Employee> repository) =>
        _repository = repository;

    public async Task<IResponse<Employee>> Handle(GetEmployeeByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.SelectByIdAsync(request.Id, cancellationToken);
    }
}
