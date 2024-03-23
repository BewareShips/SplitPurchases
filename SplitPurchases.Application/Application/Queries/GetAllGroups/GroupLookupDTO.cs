using AutoMapper;
using SplitPurchases.Application.Common.Mappings;
using SplitPurchases.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Queries.GetAllGroups
{
    public class GroupLookupDTO: IMapWith<Group>
    {
        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
        public int MemberCount { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Group, GroupLookupDTO>()
                .ForMember(d => d.GroupId, opt => opt.MapFrom(s => s.GroupId))
                .ForMember(d => d.GroupName, opt => opt.MapFrom(s => s.GroupName))
                .ForMember(d => d.MemberCount, opt => opt.MapFrom(s => s.UserGroups.Count));
        }
    }
}
