using Application.Interfaces;
using MediatR;

namespace Application.Commands.CallCommands.DeleteCall;

public record DeleteCallCommand(Guid Id) : IRequest<IResponse<Unit>>;
