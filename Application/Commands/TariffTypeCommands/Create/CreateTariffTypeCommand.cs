using Application.Interfaces;
using MediatR;

namespace Application.Commands.TariffTypeCommands.Create;
public record CreateTariffTypeCommand(string Name) : IRequest<IResponse<Guid>>;
