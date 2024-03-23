using MediatR;
using SplitPurchases.Application.Common.Exceptions;
using SplitPurchases.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.UpdatePurchase
{
    public class UpdatePurchaseCommandHandler : IRequestHandler<UpdatePurchaseCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public UpdatePurchaseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var purchase = await _context.Purchases.FindAsync(request.PurchaseId);
            if (purchase == null)
            {
                throw new NotFoundException(nameof(purchase), request.PurchaseId);
            }
            purchase.Amount = request.Amount ?? purchase.Amount;
            purchase.Name = request.Name ?? purchase.Name;
            purchase.Description = request.Description ?? purchase.Description;
            await _context.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
