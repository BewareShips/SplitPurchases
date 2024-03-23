using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitPurchases.Application.Common.Exceptions;
using SplitPurchases.Application.Interfaces;
using SplitPurchases.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Queries.GetPurchasesByGroup
{
    public class GetPurchasesByGroupQueryHandler : IRequestHandler<GetPurchasesByGroupQuery, PurchaseVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPurchasesByGroupQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PurchaseVm> Handle(GetPurchasesByGroupQuery request, CancellationToken cancellationToken)
        {
            var purchases = await _context.Purchases.Where(p => p.GroupId == request.GroupId)
                .ProjectTo<PurchaseLookupDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (purchases == null)
            {
                throw new NotFoundException(nameof(purchases), request.GroupId);
            }

            var purchaseVm = new PurchaseVm
            {
                Purchases = purchases
            };

            return purchaseVm;
        }
    }
}
