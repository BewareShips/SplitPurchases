using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.AddUser
{
    public class AddUserToGroupCommand:IRequest<bool> //The return type can be bool to indicate the success of the operation
    {
        public Guid UserId {  get; set; }
        public Guid GroupId { get; set; }
        public AddUserToGroupCommand(Guid userId, Guid groupId) { 
            UserId = userId;
            GroupId = groupId;
        }
    }
}
