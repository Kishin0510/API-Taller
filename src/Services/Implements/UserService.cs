using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.User;
using Api_Taller.src.Models;
using Api_Taller.src.Repositories.Implements;
using Api_Taller.src.Repositories.Interfaces;
using Api_Taller.src.Services.Interfaces;
using Api_Taller.src.Mappers;

namespace Api_Taller.src.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IGenderRepository genderRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _genderRepository = genderRepository;
            _roleRepository = roleRepository;
        }

        public async Task<bool> ChangeUserPassword(int id, ChangePasswordDTO changePasswordDto)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            var verifyPassword = BCrypt.Net.BCrypt.Verify(changePasswordDto.OldPassword, user.Password);
            if (!verifyPassword)
            {
                throw new Exception("La contaseña antigua no coincide");
            }

            var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(changePasswordDto.NewPassword, salt);
            var result = await _userRepository.ChangePassword(id, hashedPassword);
            return result;
        }

        public async Task<bool> ChangeUserState(int id, bool newUserState)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                throw new Exception("Usuario no encontrado");
            }
            var role  = await _roleRepository.GetRoleByName("Admin");
            if (role == null)
            {
                throw new Exception("Error del servidor");
            }
            var result = await _userRepository.ChangeUserState(id, newUserState);
            return result;
        }

        public Task<bool> EditUserInfo(int id, EditUserDTO editUserDto)
        {
            if(editUserDto.GenderId != null && !_genderRepository.ValidGenderId((int)editUserDto.GenderId).Result)
            {
                throw new Exception("Genero no valido");
            }
            var result = _userRepository.EditUser(id, editUserDto);
            return result;
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            var genders = await _genderRepository.GetGenders();
            return genders;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return users;
        }

        public async Task<IEnumerable<UserDTO>> SearchUsers(string query, int pageNum, int pageSize)
        {
            var users = await _userRepository.SearchUsers(query);
            var UserDTO = users.Skip((pageNum - 1) * pageSize).Take(pageSize).Select(u => UserMappers.ToUserDTO(u));
            return UserDTO;
        }
    }
}