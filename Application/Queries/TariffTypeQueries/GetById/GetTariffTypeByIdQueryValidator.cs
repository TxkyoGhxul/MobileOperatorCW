using FluentValidation;

namespace Application.Queries.TariffTypeQueries.GetById;
public class GetTariffTypeByIdQueryValidator : AbstractValidator<GetTariffTypeByIdQuery>
{
	public GetTariffTypeByIdQueryValidator() => RuleFor(x => x.Id).NotEqual(Guid.Empty);
}
