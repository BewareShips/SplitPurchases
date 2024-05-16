using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitPurchases.Application.Application.Services.Balance;
using SplitPurchases.Application.Common.Exceptions;
using SplitPurchases.Application.Interfaces;
using SplitPurchases.Domain.Entities.Enums;

namespace SplitPurchases.Application.Application.Commands.UpdatePurchase
{
    public class UpdatePurchaseCommandHandler : IRequestHandler<UpdatePurchaseCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly IBalanceService _balanceService;
        public UpdatePurchaseCommandHandler(IApplicationDbContext context, IBalanceService balanceService)
        {
            _context = context;
            _balanceService = balanceService;
        }

        public async Task<bool> Handle(UpdatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var purchase = await _context.Purchases
                .Where(p => p.PurchaseId == request.PurchaseId && p.PurchaseStatus != PurchaseStatus.Deleted)
                .FirstOrDefaultAsync();
            if (purchase == null)
            {
                throw new NotFoundException(nameof(purchase), request.PurchaseId);
            }

            bool isAmountChanged = purchase.Amount != request.Amount;
            purchase.Amount = request.Amount;
            purchase.Name = request.Name ?? purchase.Name;
            purchase.Description = request.Description ?? purchase.Description;
            purchase.PurchaseStatus = PurchaseStatus.Updated;
            if (isAmountChanged)
            {
                await _balanceService.UndoPurchaseAsync(purchase.PurchaseId);
                await _balanceService.DistributePurchaseCostAsync(purchase.PurchaseId);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
