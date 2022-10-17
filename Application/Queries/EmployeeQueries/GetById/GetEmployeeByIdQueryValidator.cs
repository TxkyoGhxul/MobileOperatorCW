using FluentValidation;

namespace Application.Queries.EmployeeQueries.GetById;

public class GetEmployeeByIdQueryValidator : AbstractValidator<GetEmployeeByIdQuery>
{
	public GetEmployeeByIdQueryValidator() => RuleFor(x => x.Id).NotEqual(Guid.Empty);
}
