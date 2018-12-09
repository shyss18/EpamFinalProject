using System.Collections.Generic;
using System.Data;
using EC.DataAccess.Helpers.Interface;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ICreateQuery _query;
        private readonly ICreateParameterHelper _helper;

        public RoleRepository(ICreateQuery query, ICreateParameterHelper helper)
        {
            _query = query;
            _helper = helper;
        }

        public void Create(Role item)
        {
            var titleParameter = _helper.CreateParameter("title", item.Name, DbType.String);

            _query.CreateConnection()
                .CreateCommand(DbConstants.CREATE_ROLE)
                .AddParameters(titleParameter)
                .ExecuteQuery();
        }

        public void Update(Role item)
        {
            var idParameter = _helper.CreateParameter("id", item.Id, DbType.Int32);
            var titleParameter = _helper.CreateParameter("title", item.Name, DbType.String);

            _query.CreateConnection()
                .CreateCommand(DbConstants.UPDATE_ROLE)
                .AddParameters(idParameter, titleParameter)
                .ExecuteQuery();
        }

        public void Delete(int? id)
        {
            var idParameter = _helper.CreateParameter("id", id, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.DELETE_ROLE)
                .AddParameters(idParameter)
                .ExecuteQuery();
        }

        public Role GetById(int? id)
        {
            Role role = null;

            var idParameter = _helper.CreateParameter("id", id, DbType.Int32);

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_ROLE_BY_ID)
                .AddParameters(idParameter)
                .ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    role = new Role
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Title"]
                    };
                }

                reader.Close();
            }

            return role;
        }

        public IReadOnlyCollection<Role> GetAll()
        {
            List<Role> allRoles = new List<Role>();

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_ALL_ROLES)
                .ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    var role = new Role
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Title"]
                    };

                    allRoles.Add(role);
                }

                reader.Close();
            }

            return allRoles;
        }
    }
}
