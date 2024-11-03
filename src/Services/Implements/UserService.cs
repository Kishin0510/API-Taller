using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.User;
using Api_Taller.src.Models;
using Api_Taller.src.Repositories.Interfaces;
using Api_Taller.src.Services.Interfaces;

namespace Api_Taller.src.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<bool> ChangeUserPassword(int id, ChangePasswordDTO changePasswordDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeUserState(int id, bool newUserState)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditUserInfo(int id, EditUserDTO editUserDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Gender>> GetGenders()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> SearchUsers(string query)
        {
            throw new NotImplementedException();
        }
    }
}