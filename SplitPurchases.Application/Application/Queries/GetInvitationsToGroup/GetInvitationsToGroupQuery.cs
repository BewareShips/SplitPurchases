using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Queries.GetInvitationsToGroup
{
    public class GetInvitationsToGroupQuery:IRequest<InvitationsVM>
    {
        public Guid InvitationUserId { get; set; }
        public GetInvitationsToGroupQuery(Guid invitationUserId)
        {
            InvitationUserId = invitationUserId;
        }
    }
}
