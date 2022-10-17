using FluentValidation;

namespace Application.Queries.SMSQueries.GetById;

public class GetSMSByIdQueryValidator : AbstractValidator<GetSMSByIdQuery>
{
    public GetSMSByIdQueryValidator() => RuleFor(x => x.Id).NotEqual(Guid.Empty);
}
