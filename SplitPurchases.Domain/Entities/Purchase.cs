using SplitPurchases.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Domain.Entities
{
    public class Purchase
    {
        public Guid PurchaseId { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public Guid UserId {  get; set; }
        public User User { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public string ? Description { get; set; }
        public PurchaseStatus PurchaseStatus { get; set; }
        public DateTime PurchaseDate { get; set; }
 
    }
}
