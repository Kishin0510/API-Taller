using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.User;
using Api_Taller.src.Models;

namespace Api_Taller.src.Mappers
{
    public static class UserMappers
    {
        public static UserDTO ToUserDTO(this User userModel)
        {
            return new UserDTO
            {
                Id = userModel.Id,
                Rut = userModel.RUT,
                Name = userModel.Name,
                Email = userModel.Email,
                Birthdate = userModel.Birthday,
                Active = userModel.IsEnabled,
                Rol = userModel.Role,
                Gender = userModel.Gender
            };

        }
    }
}