using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.CreateGroup
{
    public class CreateGroupCommand : IRequest<Guid>
    {
        public string GroupName { get; set; }
        public Guid CreatorId { get; set; }

        public CreateGroupCommand(string groupName, Guid creatorId)
        {
            GroupName = groupName;
            CreatorId = creatorId;
        }
    }
}
