using Microsoft.AspNetCore.Mvc;
using Api_Taller.src.DTOs.User;
using Api_Taller.src.Services.Interfaces;

namespace Api_Taller.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<LoggedUserDTO>> RegisterUser(RegisterUserDTO registerUserDto)
        {   
            try {
                var result = await _authService.RegisterUser(registerUserDto);
                return Ok(result);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoggedUserDTO>> Login(LoginUserDTO loginUserDto)
        {
            try {
                var result = await _authService.Login(loginUserDto);
                return Ok(result);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}