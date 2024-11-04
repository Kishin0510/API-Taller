using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.User;
using Api_Taller.src.Models;

namespace Api_Taller.src.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<IEnumerable<User>> SearchUsers(string query);

        Task<User?> GetUserById(int id);

        Task<User?> GetUserByEmail(string email);

        Task<bool> VerifyRut(string rut);

        Task<bool> VerifyEmail(string email);

        Task<bool> VerifyUser(int id);

        Task<bool> AddUser(User user);

        Task<bool> EditUser(int id, EditUserDTO user);

        Task<bool> ChangeUserState(int id, bool newUserState);

        Task<bool> ChangePassword(int id, string newPassword);
    }
}