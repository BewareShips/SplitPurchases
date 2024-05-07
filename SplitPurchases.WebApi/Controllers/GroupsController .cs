using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SplitPurchases.Application.Application.Commands.AddUser;
using SplitPurchases.Application.Application.Commands.CreateGroup;
using SplitPurchases.Application.Application.Queries.GetAllGroups;
using SplitPurchases.Domain.Entities;

namespace SplitPurchases.WebApi.Controllers
{
    
    public class GroupsController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateGroup(string GroupName)
        {
            var userId = UserId;
            if (userId == Guid.Empty)
            {
                return Unauthorized("User is not authenticated");
            }
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
        [HttpGet("All")]
        public async Task<IActionResult> GetAllGroups()
        {
            //var userId = UserId;
            var userId = Guid.NewGuid();
            if (userId == Guid.Empty)
            {
                return Unauthorized("User is not authenticated");
            }
            var query = new GetAllGroupsQuery(userId);
            var groups = await Mediator.Send(query);
            return Ok(groups);
        }
    }
}
