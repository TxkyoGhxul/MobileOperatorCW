using FluentValidation;

namespace Application.Queries.TariffQueries.GetById;

public class GetTariffByIdQueryValidator : AbstractValidator<GetTariffByIdQuery>
{
	public GetTariffByIdQueryValidator() => RuleFor(x => x.Id).NotEqual(Guid.Empty);
}
