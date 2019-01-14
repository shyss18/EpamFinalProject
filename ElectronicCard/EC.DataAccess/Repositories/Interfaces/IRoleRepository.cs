using System.Collections.Generic;
using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        void AddRoleToUser(int? userId, int? roleId);
        void DeleteUserRoles(int? userId);
        IReadOnlyCollection<Role> GetUserRoles(int? userId);
    }
}
