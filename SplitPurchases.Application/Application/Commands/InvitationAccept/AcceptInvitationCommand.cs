using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.InvitationAccept
{
    public class AcceptInvitationCommand:IRequest<bool>
    {
        public Guid InvitationId { get; set; }
        public Guid UserId { get; set; }
        public AcceptInvitationCommand(Guid invitationId,Guid userId) {
            InvitationId = invitationId;
            UserId = userId;
        }
    }
}
