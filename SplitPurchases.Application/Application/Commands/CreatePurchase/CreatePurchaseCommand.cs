using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.CreatePurchase
{
    public class CreatePurchaseCommand : IRequest<Guid>
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
