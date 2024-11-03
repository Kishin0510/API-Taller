using Api_Taller.src.Models;

namespace Api_Taller.src.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<bool> ValidRoleId(int id);

        Task<Role?> GetRoleById(int id);

        Task<Role?> GetRoleByName(string type);
    }
}