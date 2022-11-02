using Application.Interfaces;
using MediatR;

namespace Application.Commands.SMSCommands.Create;
public record CreateSMSCommand(Guid ContractId, DateTime Date, string Message) : IRequest<IResponse<Guid>>;
