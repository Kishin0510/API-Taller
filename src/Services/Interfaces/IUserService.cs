using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.User;
using Api_Taller.src.Models;

namespace Api_Taller.src.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> ChangeUserPassword(int id, ChangePasswordDTO changePasswordDto);

        Task<bool> EditUserInfo(int id, EditUserDTO editUserDto);

        Task<IEnumerable<User>> GetUsers();

        Task<IEnumerable<Gender>> GetGenders();

        Task<IEnumerable<UserDTO>> SearchUsers(string query, int pageNum, int pageSize);

        Task<bool> ChangeUserState(int id, bool newUserState);  

        Task<bool> DeleteUser(int id);
    }
}