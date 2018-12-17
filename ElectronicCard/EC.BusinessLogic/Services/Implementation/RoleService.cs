using System.Collections.Generic;
using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public void CreateRole(Role item)
        {
            _roleRepository.Create(item);
        }

        public void DeleteRole(int? id)
        {
            _roleRepository.Delete(id);
        }

        public void UpdateRole(Role role)
        {
            _roleRepository.Update(role);
        }

        public Role GetById(int? id)
        {
            return id == null ? null : _roleRepository.GetById(id);
        }

        public IReadOnlyCollection<Role> GetAll()
        {
            return _roleRepository.GetAll();
        }
    }
}
