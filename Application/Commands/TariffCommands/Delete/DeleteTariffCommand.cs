using MediatR;

namespace Application.Commands.TariffCommands.Delete;
public record DeleteTariffCommand(Guid Id) : IRequest;
