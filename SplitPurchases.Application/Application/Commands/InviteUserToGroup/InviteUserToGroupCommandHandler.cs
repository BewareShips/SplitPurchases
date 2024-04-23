using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitPurchases.Application.Interfaces;
using SplitPurchases.Domain.Entities;
using SplitPurchases.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.InviteUserToGroup
{
    public class InviteUserToGroupCommandHandler : IRequestHandler<InviteUserToGroupCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public InviteUserToGroupCommandHandler(IApplicationDbContext context) {
            _context = context;
        }
        public async Task<bool> Handle(InviteUserToGroupCommand request, CancellationToken cancellationToken)
        {
            var isAlreadyMember = await _context.UserGroups.AnyAsync(ug =>ug.GroupId == request.GroupId && ug.UserId == request.InvitedUserId,cancellationToken);
            if (isAlreadyMember)
            {
                return false;
            }
            var invation = new GroupInvitation
            {
                Id = Guid.NewGuid(),
                GroupId = request.GroupId,
                InvitedUserId = request.InvitedUserId,
                InvitedByUserId = request.InvitedByUserId,
                InvitateStatus = InvitationStatus.Sent,
                SendDate = DateTime.Now,
                AcceptedDate = null,
                ExpirationDate = request.ExpirationDate,
            };
       
            _context.GroupInvitations.Add(invation);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
