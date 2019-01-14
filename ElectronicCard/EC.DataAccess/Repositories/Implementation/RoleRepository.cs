using EC.Common.Helpers;
using EC.Common.Helpers.Interface;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using System.Collections.Generic;
using System.Data;

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
                allRoles.Add(new Role
                {
                    Id = (int)item["Id"],
                    Name = (string)item["Title"]
                });
            }

            return allRoles;
        }

        public void AddRoleToUser(int? userId, int? roleId)
        {
            var userParameter = _query.CreateParameter("userId", userId, DbType.Int32);
            var roleParameter = _query.CreateParameter("roleId", roleId, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.ADD_ROLE_TO_USER)
                .AddParameters(userParameter, roleParameter)
                .ExecuteQuery();
        }

        public IReadOnlyCollection<Role> GetUserRoles(int? userId)
        {
            var userParameter = _query.CreateParameter("userId", userId, DbType.Int32);

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_USER_ROLES)
                .AddParameters(userParameter)
                .ExecuteReader();

            var roles = new List<Role>();

            foreach (var item in reader)
            {
                roles.Add(new Role
                {
                    Id = (int)item["Id"],
                    Name = (string)item["Title"]
                });
            }

            return roles;
        }

        public void DeleteUserRoles(int? userId)
        {
            var idParameter = _query.CreateParameter("userId", userId, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.DELETE_USER_ROLES)
                .AddParameters(idParameter)
                .ExecuteQuery();
        }
    }
}
