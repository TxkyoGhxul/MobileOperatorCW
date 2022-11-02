using Application.Interfaces;
using MediatR;

namespace Application.Commands.SMSCommands.Delete;
public record DeleteSMSCommand(Guid Id) : IRequest<IResponse<Unit>>;
