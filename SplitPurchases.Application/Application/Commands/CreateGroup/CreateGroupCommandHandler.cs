using MediatR;
using SplitPurchases.Application.Interfaces;
using SplitPurchases.Domain.Entities;

using System.Text.RegularExpressions;
using GroupEntity = SplitPurchases.Domain.Entities.Group;


namespace SplitPurchases.Application.Application.Commands.CreateGroup
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new GroupEntity
            {
                GroupId = Guid.NewGuid(),
                GroupName = request.GroupName,
            };

            _context.Groups.Add(group);
            await _context.SaveChangesAsync(cancellationToken);
            return group.GroupId;
        }
    }


}
