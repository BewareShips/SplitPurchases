using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.InvitationAccept
{
    public class AcceptInvitationCommandValidator: AbstractValidator<AcceptInvitationCommand>
    {
        public AcceptInvitationCommandValidator() {
            RuleFor(command => command.InvitationId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("InvitationID cannot be empty.");

            RuleFor(command => command.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID cannot be empty.");
        }
    }
}
