using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.SMSQueries.GetAll;
public record GetSMSsQuery : IRequest<IResponse<IEnumerable<SMS>>>;
