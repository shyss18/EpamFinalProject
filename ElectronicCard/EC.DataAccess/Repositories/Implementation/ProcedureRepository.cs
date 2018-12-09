using System.Collections.Generic;
using System.Data;
using EC.DataAccess.Helpers.Interface;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Implementation
{
    public class ProcedureRepository : IProcedureRepository
    {
        private readonly ICreateQuery _query;
        private readonly ICreateParameterHelper _helper;

        public ProcedureRepository(ICreateQuery query, ICreateParameterHelper helper)
        {
            _query = query;
            _helper = helper;
        }

        public void Create(Procedure item)
        {
            var nameParameter = _helper.CreateParameter("name", item.Title, DbType.String);
            var descParameter = _helper.CreateParameter("description", item.Description, DbType.String);
            var timeParameter = _helper.CreateParameter("timeUse", item.TimeUse, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.CREATE_PROCEDURE)
                .AddParameters(nameParameter, descParameter, timeParameter)
                .ExecuteQuery();
        }

        public void Update(Procedure item)
        {
            var nameParameter = _helper.CreateParameter("name", item.Title, DbType.String);
            var descParameter = _helper.CreateParameter("description", item.Description, DbType.String);
            var timeParameter = _helper.CreateParameter("timeUse", item.TimeUse, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.UPDATE_PROCEDURE)
                .AddParameters(nameParameter, descParameter, timeParameter)
                .ExecuteQuery();
        }

        public void Delete(int? id)
        {
            var idParameter = _helper.CreateParameter("id", id, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.DELETE_PROCEDURE)
                .AddParameters(idParameter)
                .ExecuteQuery();
        }

        public Procedure GetById(int? id)
        {
            Procedure procedure = null;

            var idParameter = _helper.CreateParameter("id", id, DbType.Int32);

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_PROCEDURE_BY_ID)
                .AddParameters(idParameter)
                .ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    procedure = new Procedure
                    {
                        Id = (int)reader["Id"],
                        Title = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        TimeUse = (int)reader["TimeUse"]
                    };
                }

               reader.Close();
            }

            return procedure;
        }

        public IReadOnlyCollection<Procedure> GetAll()
        {
            List<Procedure> allProcedures = new List<Procedure>();

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_ALL_PROCEDURES)
                .ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    var procedure = new Procedure
                    {
                        Id = (int)reader["Id"],
                        Title = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        TimeUse = (int)reader["TimeUse"]
                    };

                    allProcedures.Add(procedure);
                }

                reader.Close();
            }

            return allProcedures;
        }
    }
}
