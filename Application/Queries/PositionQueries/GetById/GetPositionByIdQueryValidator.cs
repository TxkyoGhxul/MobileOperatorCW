using FluentValidation;

namespace Application.Queries.PositionQueries.GetById;

public class GetPositionByIdQueryValidator : AbstractValidator<GetPositionByIdQuery>
{
	public GetPositionByIdQueryValidator() => RuleFor(x => x.Id).NotEqual(Guid.Empty);
}
