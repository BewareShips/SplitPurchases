using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Queries.GetAllGroups
{
    public class GetAllGroupsQuery : IRequest<GroupVm>
    {
        public Guid UserId { get; set; }
        public GetAllGroupsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
