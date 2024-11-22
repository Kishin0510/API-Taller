using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Api_Taller.src.DTOs.User;
using Api_Taller.src.Services.Interfaces;
using Api_Taller.src.Repositories.Interfaces;
using Api_Taller.src.Models;
using Microsoft.IdentityModel.Tokens;
using Api_Taller.src.Mappers;
using System.Diagnostics;

namespace Api_Taller.src.Services.Implements
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IRoleRepository roleRepository, IGenderRepository genderRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _genderRepository = genderRepository;
            _configuration = configuration;
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>{
                new ("Id", user.Id.ToString()),
                new ("Name", user.Name),
                new ("Email", user.Email),
                new (ClaimTypes.Role, user.Role.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }        
        public async Task<LoggedUserDTO> Login(LoginUserDTO loginUserDto)
        {
            var user = await _userRepository.GetUserByEmail(loginUserDto.Email.ToString());
            if (user == null)
            {
                throw new Exception("Usuario no encontrado");
            }
            if (!user.IsEnabled)
            {
                throw new Exception("Usuario deshabilitado");
            }

            var result = BCrypt.Net.BCrypt.Verify(loginUserDto.Password, user.Password);
            if (!result)
            {
                throw new Exception("Contraseña incorrecta");
            }
            var token = CreateToken(user);
            var loggedUser = user.ToUserDTO();
            var LoggedUserDTO = new LoggedUserDTO
            {
                User = loggedUser,
                Token = token
            };
            return LoggedUserDTO;
        }

        public async Task<LoggedUserDTO> RegisterUser(RegisterUserDTO registerUserDto)
        {

            var user = registerUserDto.RegisterUserDTOToUser();
            if (!_genderRepository.ValidGenderId(user.GenderId).Result)
            {
                throw new Exception("Genero no valido");
            }
            if (_userRepository.VerifyEmail(user.Email).Result)
            {
                throw new Exception("Email ya registrado");
            }
            if (_userRepository.VerifyRut(user.RUT).Result)
            {
                throw new Exception("Rut ya registrado");
            }

            var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);
            var role = _roleRepository.GetRoleByName("User").Result;
            if (role == null)
            {
                throw new Exception("Error del servidor");
            }
            user.RoleId = role.Id;
            user.Password = hashedPassword;
            user.IsEnabled = true;

            await _userRepository.AddUser(user);
            var token = CreateToken(user);

            var loggedUser = user.ToUserDTO();

            var LoggedUserDTO = new LoggedUserDTO
            {
                User = loggedUser,
                Token = token
            };

            return LoggedUserDTO;
        }
    }
}