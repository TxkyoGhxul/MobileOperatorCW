using FluentValidation;

namespace Application.Queries.UserQueries.GetById;
public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator() => RuleFor(x => x.Id).NotEqual(Guid.Empty);
}
