using MediatR;

namespace Application.Commands.TariffTypeCommands.Create;
public record CreateTariffTypeCommand(string Name) : IRequest<Guid>;
