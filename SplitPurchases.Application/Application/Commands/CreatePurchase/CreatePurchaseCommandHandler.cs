using MediatR;
using SplitPurchases.Application.Interfaces;
using SplitPurchases.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.CreatePurchase
{
    public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        public CreatePurchaseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var purchase = new Purchase
            {
                PurchaseId = Guid.NewGuid(),
                GroupId = request.GroupId,
                UserId = request.UserId,
                Amount = request.Amount,
                Name = request.Name,
                Description = request.Description,
                PurchaseDate = DateTime.Now,
            };
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync(cancellationToken);
            return purchase.PurchaseId;
        }
    }
}
