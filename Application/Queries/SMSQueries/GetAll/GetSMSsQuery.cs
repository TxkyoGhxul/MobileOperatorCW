using Domain;
using MediatR;

namespace Application.Queries.SMSQueries.GetAll;
public record GetSMSsQuery : IRequest<IEnumerable<SMS>>;
