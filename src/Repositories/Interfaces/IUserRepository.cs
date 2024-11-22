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
        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        /// <returns>Lista con todos los usuarios. </returns>
        Task<IEnumerable<User>> GetUsers();

        /// <summary>
        /// Busca usuarios con una query.
        /// </summary>
        /// <param name="query">La query a buscar. </param>
        /// <returns>Lista de usuarios. </returns>
        Task<IEnumerable<User>> SearchUsers(string query);

        /// <summary>
        /// Obtiene un usuario por su id.
        /// </summary>
        /// <param name="id">La id del usuario. </param>
        /// <returns>Un usuario en caso de encontrarlo. </returns>
        Task<User?> GetUserById(int id);

        /// <summary>
        /// Obtiene un usuario por su email.
        /// </summary>
        /// <param name="email">Email del usuario. </param>
        /// <returns>Un usuario en caso de encontrarlo. </returns>
        Task<User?> GetUserByEmail(string email);

        /// <summary>
        /// Verifica si un rut ya está en uso.
        /// </summary>
        /// <param name="rut">Rut a verificar. </param>
        /// <returns>Booleano de confirmación. </returns>
        Task<bool> VerifyRut(string rut);

        /// <summary>
        /// Verifica si un email ya está en uso.
        /// </summary>
        /// <param name="email">Email a verificar. </param>
        /// <returns>Booleano de confirmación. </returns>
        Task<bool> VerifyEmail(string email);

        /// <summary>
        /// Verifica un usuario por id. 
        /// </summary>
        /// <param name="id">La id del usuario. </param>
        /// <returns>Booleano de confirmación. </returns>
        Task<bool> VerifyUser(int id);

        /// <summary>
        /// Añade un usuario.
        /// </summary>
        /// <param name="user">Usuario a añadir. </param>
        /// <returns>Booleano de confirmación. </returns>
        Task<bool> AddUser(User user);

        /// <summary>
        /// Editar un usuario. 
        /// </summary>
        /// <param name="id">La id del usuario. </param>
        /// <param name="user">La información a editar. </param>
        /// <returns>Booleano de confirmación. </returns>
        Task<bool> EditUser(int id, EditUserDTO user);

        /// <summary>
        /// Cambia el estado de un usuario.
        /// </summary>
        /// <param name="id">La id del usuario. </param>
        /// <param name="newUserState">El nuevo estado del usuario. </param>
        /// <returns>Booleano de confirmación. </returns>
        Task<bool> ChangeUserState(int id, bool newUserState);

        /// <summary>
        /// Cambia la contraseña de un usuario.
        /// </summary>
        /// <param name="id">La id del usuario. </param>
        /// <param name="newPassword">La nueva contraseña. </param>
        /// <returns>Booleano de confirmación. </returns>
        Task<bool> ChangePassword(int id, string newPassword);

        /// <summary>
        /// Elimina un usuario.
        /// </summary>
        /// <param name="id">La id del usuario. </param>
        /// <returns>Booleano de confirmación. </returns>
        Task<bool> DeleteUser(int id);
    }
}