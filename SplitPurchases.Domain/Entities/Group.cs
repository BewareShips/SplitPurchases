using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Domain.Entities
{
    public class Group
    {
        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; } = new HashSet<UserGroup>();
        public ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();
    }
}
