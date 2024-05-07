using Microsoft.AspNetCore.Mvc;
using SplitPurchases.Application.Application.Commands.CreateGroup;
using SplitPurchases.Application.Application.Commands.CreatePurchase;
using SplitPurchases.Application.Application.Commands.DeletePurchase;
using SplitPurchases.Application.Application.Commands.UpdatePurchase;
using SplitPurchases.Application.Application.Queries.GetPurchasesByGroup;

namespace SplitPurchases.WebApi.Controllers
{
    public class PurchaseController:BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreatePurchase([FromBody] CreatePurchaseCommand command)
        {
            var purchaseId = await Mediator.Send(command);
            return Ok(purchaseId);
        }

        [HttpGet("ByGroup/{groupId}")]
        public async Task<IActionResult> GetPurchasesByGroup(Guid groupId)
        {
            var command = new GetPurchasesByGroupQuery(groupId);
            var result = await Mediator.Send(command);
            return Ok(result);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> UpdatePurchase([FromBody] UpdatePurchaseCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);  
        }
        [HttpDelete("Delete/{purchaseId}")]
        public async Task<IActionResult> DeletePurchase(Guid purchaseId)
        {
            var command = new DeletePurchaseCommand(purchaseId);
            var result = await Mediator.Send(command);  
            return Ok(result);
        }
    }
}
