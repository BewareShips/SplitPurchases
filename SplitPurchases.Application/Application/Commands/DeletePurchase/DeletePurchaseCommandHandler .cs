using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitPurchases.Application.Application.Services.Balance;
using SplitPurchases.Application.Common.Exceptions;
using SplitPurchases.Application.Interfaces;
using SplitPurchases.Domain.Entities.Enums;


namespace SplitPurchases.Application.Application.Commands.DeletePurchase
{
    public class DeletePurchaseCommandHandler : IRequestHandler<DeletePurchaseCommand, bool>
    {   
        private readonly IApplicationDbContext _context;
        private readonly IBalanceService _balanceService;
        public DeletePurchaseCommandHandler(IApplicationDbContext context, IBalanceService balanceService)
        {
            _context = context;
            _balanceService = balanceService;

        }
        public async Task<bool> Handle(DeletePurchaseCommand request, CancellationToken cancellationToken)
        {
           

            var purchase = await _context.Purchases
                .Where(p => p.PurchaseId == request.PurchaseId && p.PurchaseStatus != PurchaseStatus.Deleted)
                .FirstOrDefaultAsync();

            if (purchase == null)
            {
                throw new NotFoundException(nameof(purchase),request.PurchaseId);
            }
            purchase.PurchaseStatus = PurchaseStatus.Deleted;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
