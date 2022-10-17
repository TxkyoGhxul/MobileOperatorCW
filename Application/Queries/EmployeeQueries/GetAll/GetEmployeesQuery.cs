using Domain;
using MediatR;

namespace Application.Queries.EmployeeQueries.GetAll;
public record GetEmployeesQuery : IRequest<IEnumerable<Employee>>;
