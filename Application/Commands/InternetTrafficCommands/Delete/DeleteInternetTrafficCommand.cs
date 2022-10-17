using MediatR;

namespace Application.Commands.InternetTrafficCommands.Delete;
public record DeleteInternetTrafficCommand(Guid Id) : IRequest;
