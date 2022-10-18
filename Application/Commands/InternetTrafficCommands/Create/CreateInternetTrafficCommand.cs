﻿using MediatR;

namespace Application.Commands.InternetTrafficCommands.Create;
public record CreateInternetTrafficCommand(Guid ContractId, DateTime Date, 
    int MbSpent) : IRequest<Guid>;