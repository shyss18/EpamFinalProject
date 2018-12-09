using System.Collections.Generic;
using System.Data;
using EC.DataAccess.Helpers.Interface;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ISqlFactory _query;

        public RoleRepository(ISqlFactory query)
        {
            _query = query;
        }

        public void Create(Role item)
        {
            var titleParameter = _query.CreateParameter("title", item.Name, DbType.String);

            _query.CreateConnection()
                .CreateCommand(DbConstants.CREATE_ROLE)
                .AddParameters(titleParameter)
                .ExecuteQuery();
        }

        public void Update(Role item)
        {
            var idParameter = _query.CreateParameter("id", item.Id, DbType.Int32);
            var titleParameter = _query.CreateParameter("title", item.Name, DbType.String);

            _query.CreateConnection()
                .CreateCommand(DbConstants.UPDATE_ROLE)
                .AddParameters(idParameter, titleParameter)
                .ExecuteQuery();
        }

        public void Delete(int? id)
        {
            var idParameter = _query.CreateParameter("id", id, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.DELETE_ROLE)
                .AddParameters(idParameter)
                .ExecuteQuery();
        }

        public Role GetById(int? id)
        {
            Role role = null;

            var idParameter = _query.CreateParameter("id", id, DbType.Int32);

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_ROLE_BY_ID)
                .AddParameters(idParameter)
                .ExecuteReader();

            foreach (var item in reader)
            {
                role = new Role
                {
                    Id = (int)item["Id"],
                    Name = (string)item["Title"]
                };
            }

            return role;
        }

        public IReadOnlyCollection<Role> GetAll()
        {
            List<Role> allRoles = new List<Role>();

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_ALL_ROLES)
                .ExecuteReader();

            foreach (var item in reader)
            {
                var role = new Role
                {
                    Id = (int)item["Id"],
                    Name = (string)item["Title"]
                };

                allRoles.Add(role);
            }

            return allRoles;
        }
    }
}
