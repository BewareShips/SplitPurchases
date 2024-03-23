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
    public class PurchaseLookupDTO : IMapWith<Purchase>
    {
        public Guid PurchaseId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Guid UserId { get; set; } //Identifier of the user who made the purchase
        public string UserName { get; set; } //Name of the user who made the purchase

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Purchase, PurchaseLookupDTO>()
                .ForMember(d => d.PurchaseId, opt => opt.MapFrom(s => s.PurchaseId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Amount, opt => opt.MapFrom(s => s.Amount))
                .ForMember(d => d.PurchaseDate, opt => opt.MapFrom(s => s.PurchaseDate))
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.User.Name));


        }
    }
}
