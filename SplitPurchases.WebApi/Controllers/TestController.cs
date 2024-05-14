using Microsoft.AspNetCore.Mvc;
using SplitPurchases.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SplitPurchases.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TestController> _logger;

        public TestController(ApplicationDbContext context, ILogger<TestController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var userCount = await _context.Users.CountAsync();
                _logger.LogInformation("Number of users in the database: {UserCount}", userCount);
                return Ok($"Number of users: {userCount}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching user count");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
