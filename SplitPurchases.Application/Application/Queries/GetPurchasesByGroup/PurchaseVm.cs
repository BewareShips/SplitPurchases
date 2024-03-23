using AutoMapper;
using SplitPurchases.Application.Common.Mappings;
using SplitPurchases.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Queries.GetPurchasesByGroup
{
    public class PurchaseVm:IMapWith<Purchase>
    {
        public IList<PurchaseLookupDTO> Purchases { get; set;}
    }
}
