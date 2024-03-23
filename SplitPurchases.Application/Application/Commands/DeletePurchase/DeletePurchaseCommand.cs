using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.DeletePurchase
{
    public class DeletePurchaseCommand:IRequest<bool>
    {
        public Guid PurchaseId { get; init; }
        public DeletePurchaseCommand(Guid purchaseId)
        {
            PurchaseId = purchaseId;
        }
    }
}
