﻿using FluentValidation;

namespace Application.Commands.EmployeeCommands.Update;
public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(x => x.Id).NotEqual(Guid.Empty);
        RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
        RuleFor(x => x.Surname).MinimumLength(3).NotEmpty();
        RuleFor(x => x.MiddleName).MinimumLength(3).NotEmpty();
        RuleFor(x => x.PositionId).NotEqual(Guid.Empty);
    }
}
