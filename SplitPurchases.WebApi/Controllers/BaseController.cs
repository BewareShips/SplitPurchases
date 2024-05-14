using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SplitPurchases.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator ? _mediator;
        protected IMediator Mediator
        {
            get
            {
                if (_mediator == null)
                {
                    _mediator = HttpContext.RequestServices.GetService<IMediator>()!;
                }
                return _mediator;
            }
        }
        protected Guid UserId {
            get
            {
                if (User?.Identity?.IsAuthenticated != true)
                {
                    return Guid.Empty;
                }

                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? Guid.Empty.ToString();
                if(userIdClaim == null)
                {
                    return Guid.Empty;
                }

                if(Guid.TryParse(userIdClaim, out var userId))
                {
                    return userId;
                }
                return Guid.Empty;
            }
        }

    }
}
