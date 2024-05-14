using SplitPurchases.Application.Common.Mappings;
using SplitPurchases.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Queries.GetInvitationsToGroup
{
    public class InvitationsVM:IMapWith<GroupInvitation>
    {
        public IList<InvitationLookupDTO> Invitations { get; set; }
    }
}
