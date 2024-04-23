using AutoMapper;
using SplitPurchases.Application.Common.Mappings;
using SplitPurchases.Domain.Entities;
using SplitPurchases.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Queries.GetInvitationsToGroup
{
    public class InvitationLookupDTO:IMapWith<GroupInvitation>
    {
        public Guid InvitationId { get; set; }
        public string GroupName { get; set; }
        public string InvitedUserName { get; set; }
        public string InventedByUserName { get; set; }
        public InvitationStatus InvitateStatus { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GroupInvitation, InvitationLookupDTO>()
                .ForMember(d => d.InvitationId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.GroupName, opt => opt.MapFrom(s => s.Group.GroupName))
                .ForMember(d => d.InvitedUserName, opt => opt.MapFrom(s => s.InvitedUser.Name))
                .ForMember(d => d.InventedByUserName, opt => opt.MapFrom(s => s.InvitedByUser.Name))
                .ForMember(d => d.InvitateStatus, opt => opt.MapFrom(s => s.InvitateStatus))
                .ForMember(d => d.SendDate, opt => opt.MapFrom(s => s.SendDate))
                .ForMember(d => d.ExpirationDate, opt => opt.MapFrom(s => s.ExpirationDate));
               

        } 
    }
}
