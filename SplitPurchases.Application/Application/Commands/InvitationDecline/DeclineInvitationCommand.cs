using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.InvitationDecline
{
    public class DeclineInvitationCommand:IRequest<bool>
    {
        public Guid InvitationId { get; set; }
        public Guid UserId { get; set; }
        public DeclineInvitationCommand(Guid invitationId, Guid userId)
        {
            InvitationId = invitationId;
            UserId = userId;
        }
    }
}
