using FluentValidation;

namespace Application.Queries.InternetTrafficQueries.GetById;
public class GetInternetTrafficByIdQueryValidator :
    AbstractValidator<GetInternetTrafficByIdQuery>
{
    public GetInternetTrafficByIdQueryValidator() => RuleFor(x => x.Id).NotEqual(Guid.Empty);
}
