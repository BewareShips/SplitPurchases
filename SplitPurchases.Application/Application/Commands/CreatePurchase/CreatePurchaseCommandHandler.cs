using MediatR;
using SplitPurchases.Application.Application.Services.Balance;
using SplitPurchases.Application.Interfaces;
using SplitPurchases.Domain.Entities;
using SplitPurchases.Domain.Entities.Enums;
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
        private readonly IBalanceService _balanceService;
        public CreatePurchaseCommandHandler(IApplicationDbContext context, IBalanceService balanceService)
        {
            _context = context;
            _balanceService = balanceService;   
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
                Description = request.Description ?? request.Description,
                PurchaseStatus = PurchaseStatus.Created,
                PurchaseDate = DateTime.Now,
            };
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync(cancellationToken);
            await _balanceService.DistributePurchaseCostAsync(purchase.PurchaseId);
            return purchase.PurchaseId;
        }
    }
}
