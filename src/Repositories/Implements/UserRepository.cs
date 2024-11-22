using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.User;
using Api_Taller.src.Models;
using Api_Taller.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Api_Taller.src.Data;

namespace Api_Taller.src.Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangePassword(int id, string newPassword)
        {
            var user = await _context.Users.FindAsync(id);
            if(user == null)
            {
                return false;
            }
            user.Password = newPassword;

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangeUserState(int id, bool newUserState)
        {
            var user = await _context.Users.FindAsync(id);
            if(user == null)
            {
                return false;
            }
            user.IsEnabled = newUserState;

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditUser(int id, EditUserDTO user)
        {
            var oldUser = await _context.Users.FindAsync(id);
            if(oldUser == null)
            {
                return false;
            }
            oldUser.Name = user.Name ?? oldUser.Name;
            oldUser.Birthday = user.Birthdate ?? oldUser.Birthday;
            oldUser.GenderId = user.GenderId ?? oldUser.GenderId;

            _context.Entry(oldUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _context.Users.Where(u => u.Email == email)
                                            .Include(u => u.Role)
                                            .Include(u => u.Gender)
                                            .FirstOrDefaultAsync();
            return user;
        }

        public async Task<User?> GetUserById(int id)
        {
            var user = await _context.Users.Where(u => u.Id == id)
                                            .Include(u => u.Role)
                                            .Include(u => u.Gender)
                                            .FirstOrDefaultAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(u => u.Role).Include(u => u.Gender).ToListAsync();
            return users;
        }

        public async Task<IEnumerable<User>> SearchUsers(string query)
        {
            if (query == null || query == "")
            {
                return await GetUsers();
            } else {
            var users = await _context.Users.Where(u => u.Id.ToString().Contains(query) 
                                            || u.Name.Contains(query) 
                                            || u.Email.Contains(query) 
                                            || u.RUT.Contains(query)
                                            || u.IsEnabled.ToString().Contains(query)
                                            || u.Birthday.ToString().Contains(query)
                                            || u.Gender.Type.Contains(query))
                                            .Include(u => u.Role)
                                            .Include(u => u.Gender)
                                            .ToListAsync();
            return users;
            }
        }

        public async Task<bool> VerifyEmail(string email)
        {
            var user = await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if(user == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> VerifyRut(string rut)
        {
            var user = await _context.Users.Where(u => u.RUT == rut).FirstOrDefaultAsync();
            if(user == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> VerifyUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}