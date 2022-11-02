using Application.Interfaces;
using MediatR;

namespace Application.Commands.TariffTypeCommands.Update;
public record UpdateTariffTypeCommand(Guid Id, string Name) : IRequest<IResponse<Unit>>;
