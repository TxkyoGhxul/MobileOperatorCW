using Application.Interfaces;
using MediatR;

namespace Application.Commands.TariffCommands.Update;
public record UpdateTariffCommand(Guid Id, string Name, decimal Cost, decimal LocalCost,
    decimal TownCost, decimal CountryCost, decimal SMSCost, decimal MbCost,
    Guid TariffTypeId) : IRequest<IResponse<Unit>>;
