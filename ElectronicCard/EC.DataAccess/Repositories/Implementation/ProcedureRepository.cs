using System.Collections.Generic;
using System.Data;
using EC.DataAccess.Helpers.Interface;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Implementation
{
    public class ProcedureRepository : IProcedureRepository
    {
        private readonly ISqlFactory _query;

        public ProcedureRepository(ISqlFactory query)
        {
            _query = query;
        }

        public void Create(Procedure item)
        {
            var nameParameter = _query.CreateParameter("name", item.Title, DbType.String);
            var descParameter = _query.CreateParameter("description", item.Description, DbType.String);
            var timeParameter = _query.CreateParameter("timeUse", item.TimeUse, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.CREATE_PROCEDURE)
                .AddParameters(nameParameter, descParameter, timeParameter)
                .ExecuteQuery();
        }

        public void Update(Procedure item)
        {
            var idParameter = _query.CreateParameter("id", item.Id, DbType.Int32);
            var nameParameter = _query.CreateParameter("name", item.Title, DbType.String);
            var descParameter = _query.CreateParameter("description", item.Description, DbType.String);
            var timeParameter = _query.CreateParameter("timeUse", item.TimeUse, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.UPDATE_PROCEDURE)
                .AddParameters(idParameter, nameParameter, descParameter, timeParameter)
                .ExecuteQuery();
        }

        public void Delete(int? id)
        {
            var idParameter = _query.CreateParameter("id", id, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.DELETE_PROCEDURE)
                .AddParameters(idParameter)
                .ExecuteQuery();
        }

        public Procedure GetById(int? id)
        {
            Procedure procedure = null;

            var idParameter = _query.CreateParameter("id", id, DbType.Int32);

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_PROCEDURE_BY_ID)
                .AddParameters(idParameter)
                .ExecuteReader();

            foreach (var item in reader)
            {
                procedure = new Procedure
                {
                    Id = (int)item["Id"],
                    Title = (string)item["Name"],
                    Description = (string)item["Description"],
                    TimeUse = (int)item["TimeUse"]
                };
            }

            return procedure;
        }

        public IReadOnlyCollection<Procedure> GetAll()
        {
            List<Procedure> allProcedures = new List<Procedure>();

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_ALL_PROCEDURES)
                .ExecuteReader();

            foreach (var item in reader)
            {
                var procedure = new Procedure
                {
                    Id = (int)item["Id"],
                    Title = (string)item["Name"],
                    Description = (string)item["Description"],
                    TimeUse = (int)item["TimeUse"]
                };

                allProcedures.Add(procedure);
            }

            return allProcedures;
        }
    }
}
