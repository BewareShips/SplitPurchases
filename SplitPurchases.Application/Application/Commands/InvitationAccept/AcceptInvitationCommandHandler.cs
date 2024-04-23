using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitPurchases.Application.Interfaces;
using SplitPurchases.Domain.Entities;
using SplitPurchases.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.InvitationAccept
{
    public class AcceptInvitationCommandHandler : IRequestHandler<AcceptInvitationCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public AcceptInvitationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AcceptInvitationCommand request, CancellationToken cancellationToken)
        {
            var invitation = await _context.GroupInvitations.FirstOrDefaultAsync(gi => gi.Id == request.InvitationId && gi.InvitedUserId == request.UserId);
            if (invitation == null || invitation.InvitedUserId == null || invitation.InvitateStatus != InvitationStatus.Sent)
            {
                return false;
            }
            invitation.InvitateStatus = InvitationStatus.Accepted;
            //Searching for other invitations, if we do not find ToListAsync will return empty list
            var otherInvitations =
                await _context.GroupInvitations.Where(
                    gi => gi.GroupId == invitation.GroupId && gi.InvitedUserId == invitation.InvitedUserId &&
                    gi.Id != invitation.Id && invitation.InvitateStatus == InvitationStatus.Sent
                ).ToListAsync(cancellationToken);
            // if otherinvitations exist we changing InviteStatus
            foreach(var otherInv in otherInvitations)
            {
                otherInv.InvitateStatus = InvitationStatus.Invalid;
            }

            
                var userAdding = new UserGroup
                {
                    UserId = invitation.InvitedUserId.Value,
                    GroupId = invitation.GroupId,
                };
                _context.UserGroups.Add(userAdding);
            

           
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
