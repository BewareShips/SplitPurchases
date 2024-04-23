using MediatR;
using SplitPurchases.Application.Common.Exceptions;
using SplitPurchases.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.DeletePurchase
{
    public class DeletePurchaseCommandHandler : IRequestHandler<DeletePurchaseCommand, bool>
    {   
        private readonly IApplicationDbContext _context;
        public DeletePurchaseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeletePurchaseCommand request, CancellationToken cancellationToken)
        {
            var purchase = await _context.Purchases.FindAsync(request.PurchaseId);
            if (purchase == null)
            {
                throw new NotFoundException(nameof(purchase),request.PurchaseId);
            }
            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
