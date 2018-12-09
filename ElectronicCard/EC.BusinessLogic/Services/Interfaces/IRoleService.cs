using System.Collections.Generic;
using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Interfaces
{
    public interface IRoleService
    {
        void CreateRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int? id);
        Role GetById(int? id);
        IReadOnlyCollection<Role> GetAll();
    }
}
