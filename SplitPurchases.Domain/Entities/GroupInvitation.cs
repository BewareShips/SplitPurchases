using SplitPurchases.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Domain.Entities
{
    public class GroupInvitation
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public Guid ? InvitedUserId { get; set; }
        public User InvitedUser { get; set; }
        public Guid ? InvitedByUserId { get; set; }
        public User InvitedByUser { get; set; }
        public InvitationStatus InvitateStatus { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public DateTime ExpirationDate { get; set;}
        
    }
}
