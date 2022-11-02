using Application.Interfaces;
using MediatR;

namespace Application.Commands.ContractCommands.Create;
public record CreateContractCommand(DateTime Date, string PhoneNumber, Guid UserId, 
    Guid EmployeeId, Guid TariffId) : IRequest<IResponse<Guid>>;
