using Application.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var result = await _authService.RegisterAsync(model);
            return Ok(new { message = result });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var result = await _authService.LoginAsync(model);
            return Ok(new { token = result });
        }

    }
}
