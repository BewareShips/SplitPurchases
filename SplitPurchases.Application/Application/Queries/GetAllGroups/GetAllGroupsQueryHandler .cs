using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitPurchases.Application.Common.Exceptions;
using SplitPurchases.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Queries.GetAllGroups
{
    public class GetAllGroupsQueryHandler : IRequestHandler<GetAllGroupsQuery, GroupVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllGroupsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GroupVm> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
        {
            
            var groups = await _context.UserGroups.Where(ug => ug.UserId == request.UserId)
                .ProjectTo<GroupLookupDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (groups == null)
            {
                throw new NotFoundException(nameof(groups), request.UserId);
            }

            var groupsVm = new GroupVm
            {
                Groups = groups
            };

            return groupsVm;
        }
    }
}
