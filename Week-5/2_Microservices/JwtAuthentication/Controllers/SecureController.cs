using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController:ControllerBase
    {
        [HttpGet("data")]
        [Authorize]
        public IActionResult GetSecureData()
        {
            return Ok("This is protected data.");
        }

        [HttpGet("admin")]
        [Authorize(Roles="Admin")]
        public IActionResult GetAdminData()
        {
            return Ok("Admin only content.");
        }
    }
}
