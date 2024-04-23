using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitPurchases.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Queries.GetInvitationsToGroup
{
    public class GetInvitationsToGroupQueryHandler : IRequestHandler<GetInvitationsToGroupQuery, InvitationsVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetInvitationsToGroupQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InvitationsVM> Handle(GetInvitationsToGroupQuery request, CancellationToken cancellationToken)
        {
            var userInvitations = await _context.GroupInvitations.Where(i => i.InvitedUserId == request.InvitationUserId).
                ProjectTo<InvitationLookupDTO>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            var invitationsVm = new InvitationsVM
            {
                Invitations = userInvitations,
            };

            return invitationsVm;
        }
    }
}
