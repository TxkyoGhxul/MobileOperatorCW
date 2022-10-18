﻿using MediatR;

namespace Application.Commands.TariffTypeCommands.Delete;
public record DeleteTariffTypeCommand(Guid Id) : IRequest;