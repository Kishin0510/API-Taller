using Api_Taller.src.DTOs.User;
namespace Api_Taller.src.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoggedUserDTO> RegisterUser(RegisterUserDTO registerUserDto);

        Task<LoggedUserDTO> Login(LoginUserDTO loginUserDto);   
    }
}