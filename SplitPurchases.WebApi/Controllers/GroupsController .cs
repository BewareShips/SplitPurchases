using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SplitPurchases.Application.Application.Commands.AddUser;
using SplitPurchases.Application.Application.Commands.CreateGroup;

namespace SplitPurchases.WebApi.Controllers
{
    
    public class GroupsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateGroup(string GroupName, Guid userId)
        {
            var query = new CreateGroupCommand (GroupName, userId);
            var groupId = await Mediator.Send(query);
            return Ok(groupId);
        }
        [HttpPost("{groupId}")]
        public async Task<IActionResult> AddUserToGroup(Guid groupId, Guid userId)
        {
            //var query = new AddUserToGroupCommand(groupId, userId);
            //var result = await Mediator.Send(query);
            //return Ok(result);
            return  StatusCode(StatusCodes.Status501NotImplemented, "Adding directly to the group temporarily unavailable until adding admin roles");
        }
    }
}
