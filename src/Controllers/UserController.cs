using Microsoft.AspNetCore.Mvc;
using Api_Taller.src.Models;
using Microsoft.AspNetCore.Authorization;
using Api_Taller.src.DTOs.User;
using Api_Taller.src.Services.Interfaces;

namespace Api_Taller.src.Controllers
{
    [ApiController]
    [Route("api/user")]

    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpPut("{id}/password")]
        [Authorize]
        public async Task<ActionResult<string>> ChangePassword (int id, [FromBody] ChangePasswordDTO changePasswordDto)
        {
            try
            {   var idClaim = User.Claims.FirstOrDefault(claim => claim.Type == "Id");
                if (idClaim != null && int.Parse(idClaim.Value) != id)
                {
                    return Unauthorized("No puedes cambiar la contraseña de otro usuario");
                }
                var result = await _userService.ChangeUserPassword(id, changePasswordDto);
                if (!result) {
                    return BadRequest("No se pudo cambiar la contraseña");
                }
                return Ok("Contraseña cambiada con éxito");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}/state")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> ChangeUserState(int id, [FromBody] string newState)
        {
            try
            {
                bool state = bool.Parse(newState);
                var result = await _userService.ChangeUserState(id, state);
                if (!result)
                {
                    return BadRequest("No se pudo cambiar el estado del usuario");
                }
                return Ok("Estado del usuario cambiado con éxito");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> EditUser(int id, [FromBody] EditUserDTO editUserDTO)
        {
            try {
                var idClaim = User.Claims.FirstOrDefault(claim => claim.Type == "Id");
                if(idClaim != null && int.Parse(idClaim.Value) != id)
                {
                    return Unauthorized("No puedes editar la información de otro usuario");
                }
                var result = await _userService.EditUserInfo(id, editUserDTO);
                if (!result)
                {
                    return BadRequest("No se pudo editar la información del usuario");
                }
                return Ok("Información del usuario editada con éxito");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("search/{pageNum}/{pageSize}")]
        [Authorize (Roles = "Admin")]
        public ActionResult<IEnumerable<UserDTO>> SearchUsers([FromQuery] string? query,int pageNum, int pageSize)
        {
            var user = _userService.SearchUsers(query, pageNum, pageSize);
            if (user == null)
            {
                return BadRequest("Usuario no encontrado");
            }
            return Ok(user);
        }

        [HttpDelete("delete/{id}")]
        [Authorize (Roles = "User")]
        public async Task<ActionResult<string>> DeleteUser(int id)
        {
            try {
                var idClaim = User.Claims.FirstOrDefault(claim => claim.Type == "Id");
                if(idClaim != null && int.Parse(idClaim.Value) != id)
                {
                    return Unauthorized("No puedes elimiar la cuenta de otro usuario");
                }
                var result = await _userService.DeleteUser(id);
                if (!result)
                {
                    return BadRequest("No se pudo eliminar el usuario");
                }
                return Ok("Usuario eliminado con éxito");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}