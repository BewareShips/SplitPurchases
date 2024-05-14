using Microsoft.AspNetCore.Mvc;
using SplitPurchases.Application.Application.Commands.CreateUser;
using SplitPurchases.Application.Application.Commands.InvitationAccept;
using SplitPurchases.Application.Application.Commands.InvitationDecline;
using SplitPurchases.Application.Application.Commands.InviteUserToGroup;
using SplitPurchases.Application.Application.Queries.GetInvitationsToGroup;

namespace SplitPurchases.WebApi.Controllers
{
    public class UsersController:BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser(string userName, string email)
        {
            var query = new CreateUserCommand(userName, email);
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("invitations")]
        public async Task<IActionResult> GetMyInvitations()
        {
            var userid = UserId;
            if(userid == Guid.Empty)
            {
                return Unauthorized("User is not authenticated");
            }
            var query = new GetInvitationsToGroupQuery(userid);
            var invitations = await Mediator.Send(query);
            return Ok(invitations);
        }

        [HttpPost("Invite")]
        public async Task<IActionResult> InviteUserToGroup([FromBody] InviteUserToGroupCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("AcceptInvitation")]
        public async Task<IActionResult> AcceptInvitation(Guid invitationId, Guid userId)
        {
            var query = new AcceptInvitationCommand(invitationId, userId);
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost("DeclineInvitation")]
        public async Task<IActionResult>DeclineInvitation(Guid invitationId, Guid userId)
        {
            var query = new DeclineInvitationCommand(invitationId, userId);
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
