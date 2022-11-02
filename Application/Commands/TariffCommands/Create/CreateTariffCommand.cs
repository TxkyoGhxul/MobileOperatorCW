using Application.Interfaces;
using MediatR;

namespace Application.Commands.TariffCommands.Create;
public record CreateTariffCommand(string Name, decimal Cost, decimal LocalCost,
    decimal TownCost, decimal CountryCost, decimal SMSCost, decimal MbCost,
    Guid TariffTypeId) : IRequest<IResponse<Guid>>;
