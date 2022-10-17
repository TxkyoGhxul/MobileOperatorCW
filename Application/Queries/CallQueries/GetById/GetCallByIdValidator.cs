using FluentValidation;

namespace Application.Queries.CallQueries.GetById;
public class GetCallByIdValidator : AbstractValidator<GetCallByIdQuery>
{
    public GetCallByIdValidator() => RuleFor(x => x.Id).NotEqual(Guid.Empty);
}
