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

        /// <summary>
        /// Registrar un nuevo usuario.
        /// </summary>
        /// <param name="registerUserDto">Los datos para registrarse. </param>
        /// <returns>Un mensaje de confirmación. </returns>
        
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

        /// <summary>
        /// Inicia sesión un usuario existente.
        /// </summary>
        /// <param name="loginUserDto">Los datos de inicio de sesión</param>
        /// <returns>Los datos del usuario que inició sesión. </returns>
        [HttpPost("login")]
        public async Task<ActionResult<LoggedUserDTO>> Login(LoginUserDTO loginUserDto)
        {
            try {
                var result = await _authService.Login(loginUserDto);
                return Ok(result);

            } catch (Exception e) {
                return BadRequest(new {message = e.Message});
            }
        }
    }
}