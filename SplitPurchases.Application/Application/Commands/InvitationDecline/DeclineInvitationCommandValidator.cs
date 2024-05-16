using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.InvitationDecline
{
    public class DeclineInvitationCommandValidator: AbstractValidator<DeclineInvitationCommand>
    {
        public DeclineInvitationCommandValidator(){
            RuleFor(command => command.InvitationId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("InvitationID cannot be empty.");

            RuleFor(command => command.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID cannot be empty.");
        }
    }
}
