using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Queries.GetInvitationsToGroup
{
    public class GetInvitationsToGroupQueryValidator: AbstractValidator<GetInvitationsToGroupQuery>
    {
        public GetInvitationsToGroupQueryValidator()
        {
            RuleFor(query => query.InvitationUserId)
                .NotEqual(Guid.Empty)
                .WithMessage("InvitationUser ID cannot be empty.");
        }
    }
}
