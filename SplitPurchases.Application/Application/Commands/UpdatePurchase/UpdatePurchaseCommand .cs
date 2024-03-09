using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.UpdatePurchase
{
    public class UpdatePurchaseCommand:IRequest<bool>
    {
        public Guid PurchaseId { get; set; }
        public decimal ? Amount { get; set; }
        public string Name { get; set; }
        public string Description {  get; set; }
        public UpdatePurchaseCommand(Guid purchaseId, decimal amount, string name,string description) { 
            PurchaseId = purchaseId;
            Amount = amount;
            Name = name;
            Description = description;
        }
    }
}
