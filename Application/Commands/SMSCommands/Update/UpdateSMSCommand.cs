using Application.Interfaces;
using MediatR;

namespace Application.Commands.SMSCommands.Update;
public record UpdateSMSCommand(Guid Id, Guid ContractId, DateTime Date,
    string Message) : IRequest<IResponse<Unit>>;
