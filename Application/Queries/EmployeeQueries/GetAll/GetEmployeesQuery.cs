using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.EmployeeQueries.GetAll;
public record GetEmployeesQuery : IRequest<IResponse<IEnumerable<Employee>>>;
