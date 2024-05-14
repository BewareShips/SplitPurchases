using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Domain.Entities.Enums
{
    public enum PurchaseStatus
    {
        Created = 1,
        Updated = 2,
        Deleted = 3
    }
}
