using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.InviteUserToGroup
{
    public class InviteUserToGroupCommand:IRequest<bool>
    {
        public Guid GroupId { get; set; }
        public Guid InvitedUserId { get; set; }
        public Guid InvitedByUserId { get; set; }
        public  DateTime ExpirationDate { get; set; }

        public InviteUserToGroupCommand (Guid groupId, Guid invitedUserId, Guid invitedByUserId, DateTime expirationDate)
        {
            GroupId = groupId;
            InvitedUserId = invitedUserId;
            InvitedByUserId = invitedByUserId;
            ExpirationDate = expirationDate;
        }
    }
}
