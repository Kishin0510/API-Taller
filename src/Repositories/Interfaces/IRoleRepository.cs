using Api_Taller.src.Models;

namespace Api_Taller.src.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        /// <summary>
        /// Valida si un rol existe.
        /// </summary>
        /// <param name="id">La id del rol. </param>
        /// <returns>Booleano de confirmación. </returns>
        Task<bool> ValidRoleId(int id);

        /// <summary>
        /// Obtiene un rol por su id.
        /// </summary>
        /// <param name="id">La id del rol. </param>
        /// <returns>El rol buscado. </returns>
        Task<Role?> GetRoleById(int id);

        /// <summary>
        /// Obtiene un rol por su nombre.
        /// </summary>
        /// <param name="type">El tipo de rol. </param>
        /// <returns>El rol buscado. </returns>
        Task<Role?> GetRoleByName(string type);
    }
}