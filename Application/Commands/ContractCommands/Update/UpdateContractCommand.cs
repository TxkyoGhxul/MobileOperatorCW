using Application.Interfaces;
using MediatR;

namespace Application.Commands.ContractCommands.Update;
public record UpdateContractCommand(Guid Id, DateTime Date, string PhoneNumber, Guid UserId,
    Guid EmployeeId, Guid TariffId) : IRequest<IResponse<Unit>>;
