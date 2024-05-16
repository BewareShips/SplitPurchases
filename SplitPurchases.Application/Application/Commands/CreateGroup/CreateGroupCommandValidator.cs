using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.CreateGroup
{
    public class CreateGroupCommandValidator:AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator()
        {
            RuleFor(command => command.GroupName)
                .NotEmpty().WithMessage("Group name cannot be empty.")
                .MinimumLength(3).WithMessage("Group name must be at least 3 characters long.");

            RuleFor(command => command.CreatorId)
                .NotEqual(Guid.Empty)
                .WithMessage("Creator ID cannot be empty.");
        }
    }
}
