using EC.Common.Helpers;
using EC.Common.Helpers.Interface;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using System.Collections.Generic;
using System.Data;

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
                allProcedures.Add(new Procedure
                {
                    Id = (int)item["Id"],
                    Title = (string)item["Name"],
                    Description = (string)item["Description"],
                    TimeUse = (int)item["TimeUse"]
                });
            }

            return allProcedures;
        }

        public void AddProcedureToRecord(int? procedureId, int? recordId)
        {
            var procedureParameter = _query.CreateParameter("idProcedure", procedureId, DbType.Int32);
            var recordParameter = _query.CreateParameter("idRecord", recordId, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.ADD_PROCEDURE_TO_RECORD)
                .AddParameters(recordParameter, procedureParameter)
                .ExecuteQuery();
        }

        public IReadOnlyCollection<Procedure> GetProceduresByRecordId(int? recordId)
        {
            var recordParameter = _query.CreateParameter("idRecord", recordId, DbType.Int32);

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_PROCEDURES_BY_RECORD)
                .AddParameters(recordParameter)
                .ExecuteReader();

            var procedures = new List<Procedure>();

            foreach (var item in reader)
            {
                procedures.Add(new Procedure
                {
                    Id = (int)item["Id"],
                    Title = (string)item["Name"],
                    TimeUse = (int)item["TimeUse"],
                    Description = (string)item["Description"]
                });
            }

            return procedures;
        }
    }
}
