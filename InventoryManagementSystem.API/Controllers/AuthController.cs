using InventoryManagementSystem.Domain.Interfaces;
using InventoryManagementSystem.Domain.Models.User;
using InventoryManagementSystem.Infrastructure.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            if (model == null)
            {
                return BadRequest("Invalid client request");
            }

            var result = await _loginService.LoginAsync(model);

            if (result.Success)
            {
                return Ok(new
                {
                    token = result.Token,
                    expiration = result.Expiration
                });
            }

            return Unauthorized(result.Error);
        }
    }
}
