using Domain;
using MediatR;

namespace Application.Queries.EmployeeQueries.GetById;
public record GetEmployeeByIdQuery(Guid Id) : IRequest<Employee>;
