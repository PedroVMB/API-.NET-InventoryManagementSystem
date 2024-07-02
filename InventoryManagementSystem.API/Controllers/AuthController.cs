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
        private readonly IRegisterService _registerService;

        public AuthController(ILoginService loginService, IRegisterService registerService)
        {
            _loginService = loginService;
            _registerService = registerService;
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

        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdministrator([FromBody] RegisterModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid client request");
            }

            var result = await _registerService.RegisterAdminAsync(model);

            if (result.Success)
            {
                return Ok(new { Status = "Success", Message = result.Message });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = result.Message });
        }

        [HttpPost("register-manager")]
        public async Task<IActionResult> RegisterManager([FromBody] RegisterModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid client request");
            }

            var result = await _registerService.RegisterManagerAsync(model);

            if (result.Success)
            {
                return Ok(new { Status = "Success", Message = result.Message });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = result.Message });
        }

        [HttpPost("register-seller")]
        public async Task<IActionResult> RegisterSeller([FromBody] RegisterModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid client request");
            }

            var result = await _registerService.RegisterSellerAsync(model);

            if (result.Success)
            {
                return Ok(new { Status = "Success", Message = result.Message });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = result.Message });
        }
    }
}
