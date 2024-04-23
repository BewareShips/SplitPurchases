using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitPurchases.Application.Interfaces;
using SplitPurchases.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.InvitationDecline
{
    public class DeclineInvitationCommandHandler : IRequestHandler<DeclineInvitationCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public DeclineInvitationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeclineInvitationCommand request, CancellationToken cancellationToken)
        {
            var invitation = await _context.GroupInvitations.FirstOrDefaultAsync(gi => gi.Id == request.InvitationId && gi.InvitedUserId == request.UserId,cancellationToken);

            if(invitation == null)
            {
                return false;
            }
            invitation.InvitateStatus = InvitationStatus.Declined;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
