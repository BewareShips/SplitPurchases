using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.InviteUserToGroup
{
    public class InviteUserToGroupCommandValidator: AbstractValidator<InviteUserToGroupCommand>
    {
        public InviteUserToGroupCommandValidator()
        {
            RuleFor(command => command.GroupId)
                .NotEqual(Guid.Empty)
                .WithMessage("Group ID cannot be empty.");

            RuleFor(command => command.InvitedUserId)
                .NotEqual(Guid.Empty)
                .WithMessage("Invited User ID cannot be empty.");

            RuleFor(command => command.InvitedByUserId)
                .NotEqual(Guid.Empty)
                .WithMessage("Inviting User ID cannot be empty.");

            RuleFor(command => command.ExpirationDate)
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("Expiration date must be in the future.");
        }
    }
}
