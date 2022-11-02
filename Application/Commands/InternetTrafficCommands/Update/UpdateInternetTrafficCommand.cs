using Application.Interfaces;
using MediatR;

namespace Application.Commands.InternetTrafficCommands.Update;
public record UpdateInternetTrafficCommand(Guid Id, Guid ContractId, DateTime Date,
    int MbSpent) : IRequest<IResponse<Unit>>;
