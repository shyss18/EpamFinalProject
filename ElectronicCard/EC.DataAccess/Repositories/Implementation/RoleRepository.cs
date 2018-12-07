using System;
using System.Data;
using EC.DataAccess.Helpers.Interface;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ICreateQuery _query;
        private readonly IHelper _helper;

        public RoleRepository(ICreateQuery query, IHelper helper)
        {
            _query = query;
            _helper = helper;
        }

        public void Create(Role item)
        {
            var titleParameter = _helper.CreateParameter("title")
                .WithValue(item.Name)
                .WithType(DbType.String)
                .Create();

            _query.CreateConnection()
                .CreateCommand(DbConstants.CREATE_ROLE)
                .AddParameters(titleParameter)
                .ExecuteQuery();
        }

        public void Update(Role item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            var idParameter = _helper.CreateParameter("id")
                .WithValue(id)
                .WithType(DbType.Int32)
                .Create();

            _query.CreateConnection()
                .CreateCommand(DbConstants.DELETE_ROLE)
                .AddParameters(idParameter)
                .ExecuteQuery();
        }

        public Role GetById(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
