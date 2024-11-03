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
        public static User RegisterUserDTOToUser(this RegisterUserDTO registerUserDTO)
        {
            return new User
            {

                RUT = registerUserDTO.Rut,
                Name = registerUserDTO.Name,
                Birthday = DateTime.Parse(registerUserDTO.Birthday),
                Email = registerUserDTO.Email,
                GenderId = int.Parse(registerUserDTO.GenderId)

            };
        }
    }
}