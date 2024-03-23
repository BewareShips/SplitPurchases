using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitPurchases.Application.Interfaces;
using SplitPurchases.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.AddUser
{
    public class AddUserToGroupCommandHandler : IRequestHandler<AddUserToGroupCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public AddUserToGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(AddUserToGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _context.Groups.FindAsync(request.GroupId);
            var user = await _context.Users.FindAsync(request.UserId);

            if (group == null || user == null)
            {
                return false; // group or user didn't find
            }
            var UserAlreadyInGroup = await _context.UserGroups.AnyAsync(ug => ug.UserId == request.UserId && ug.GroupId == request.GroupId);
            if (UserAlreadyInGroup)
            {
                return false; //user already in group
            }
            var userGroup = new UserGroup { UserId = request.UserId, GroupId = request.GroupId };
            _context.UserGroups.Add(userGroup);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
