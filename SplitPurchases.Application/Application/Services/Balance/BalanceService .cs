using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SplitPurchases.Application.Application.Queries.GetPurchasesByGroup;
using SplitPurchases.Application.Common.Exceptions;
using SplitPurchases.Application.Interfaces;
using SplitPurchases.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Services.Balance
{
    public class BalanceService : IBalanceService
    {
        private readonly IApplicationDbContext _context;
        public BalanceService(IApplicationDbContext context) 
        { 
            _context = context;
        }

        public async Task DistributePurchaseCostAsync(Guid purchaseId)
        {
            var purchase = await GetPurchase(purchaseId);
            await AdjustBalancesAsync(purchase, true);
        }

        public async Task UndoPurchaseAsync(Guid purchaseId)
        {
            var purchase = await GetPurchase(purchaseId);
            await AdjustBalancesAsync(purchase, false);
        }

        private async Task<Purchase> GetPurchase(Guid purchaseId)
        {
            var purchase = await _context.Purchases
                .Include(p => p.Group)
                .ThenInclude(g => g.UserGroups)
                .FirstOrDefaultAsync(p => p.PurchaseId == purchaseId);
            if (purchase == null)
            {
                throw new NotFoundException(nameof(purchase), purchaseId);
            }
            return purchase;
        }

        private async Task AdjustBalancesAsync(Purchase purchase, bool apply)
        {
            var usersInGroup = purchase.Group.UserGroups;
            var shareBetweenUsers = purchase.Amount / usersInGroup.Count();

            foreach (var userGroup in usersInGroup)
            {
                if (userGroup.UserId == purchase.UserId)
                {
                    if (apply) {
                        userGroup.Balance += purchase.Amount;
                    } else {
                        userGroup.Balance -=  purchase.Amount;
                    }
                }
                else
                {
                    if (apply){
                        userGroup.Balance -=  shareBetweenUsers;
                    } else {
                        userGroup.Balance += shareBetweenUsers;
                    }
                    
                }
                _context.UserGroups.Update(userGroup);
            }
            await _context.SaveChangesAsync();
        }

    }
}
