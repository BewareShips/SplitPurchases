using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Queries.GetPurchasesByGroup
{
    public class GetPurchasesByGroupQuery: IRequest<PurchaseVm>
    {
        public Guid GroupId { get; set; }

        public GetPurchasesByGroupQuery(Guid groupId)
        {
            GroupId = groupId;
        }
    }
}
