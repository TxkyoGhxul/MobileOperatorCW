using Domain;
using MediatR;

namespace Application.Queries.SMSQueries.GetById;
public record GetSMSByIdQuery(Guid Id) : IRequest<SMS>;
