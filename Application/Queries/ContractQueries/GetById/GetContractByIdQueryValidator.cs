using FluentValidation;

namespace Application.Queries.ContractQueries.GetById;

public class GetContractByIdQueryValidator : AbstractValidator<GetContractByIdQuery>
{
	public GetContractByIdQueryValidator() => RuleFor(x => x.Id).NotEqual(Guid.Empty);
}
