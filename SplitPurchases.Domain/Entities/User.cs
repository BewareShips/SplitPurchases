using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set;}
        public string Name { get; set;}
        public string Email { get; set;}
        public ICollection<UserGroup>UserGroups { get; set;} = new HashSet<UserGroup>();
        public ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();

    }
}
