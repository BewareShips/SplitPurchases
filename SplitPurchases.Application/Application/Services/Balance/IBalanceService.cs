using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Services.Balance
{
    public interface IBalanceService
    {
        Task DistributePurchaseCostAsync(Guid purchaseId);
        Task UndoPurchaseAsync (Guid purchaseId);
    }
}
