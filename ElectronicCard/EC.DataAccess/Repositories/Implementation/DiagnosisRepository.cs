using EC.Common.Helpers;
using EC.Common.Helpers.Interface;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using System.Collections.Generic;
using System.Data;

namespace EC.DataAccess.Repositories.Implementation
{
    public class DiagnosisRepository : IDiagnosisRepository
    {
        private readonly ISqlFactory _query;

        public DiagnosisRepository(ISqlFactory query)
        {
            _query = query;
        }

        public void Create(Diagnosis item)
        {
            var titleParameter = _query.CreateParameter("title", item.Title, DbType.String);

            _query.CreateConnection()
                .CreateCommand(DbConstants.CREATE_DIAGNOSIS)
                .AddParameters(titleParameter)
                .ExecuteQuery();
        }

        public void Update(Diagnosis item)
        {
            var idParameter = _query.CreateParameter("id", item.Id, DbType.Int32);
            var titleParameter = _query.CreateParameter("title", item.Title, DbType.String);

            _query.CreateConnection()
                .CreateCommand(DbConstants.UPDATE_DIAGNOSIS)
                .AddParameters(idParameter, titleParameter)
                .ExecuteQuery();
        }

        public void Delete(int? id)
        {
            var idParameter = _query.CreateParameter("id", id, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.DELETE_DIAGNOSIS)
                .AddParameters(idParameter)
                .ExecuteQuery();
        }

        public Diagnosis GetById(int? id)
        {
            var idParameter = _query.CreateParameter("id", id, DbType.Int32);

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_BY_ID_DIAGNOSIS)
                .AddParameters(idParameter)
                .ExecuteReader();

            Diagnosis diagnosis = null;

            foreach (var item in reader)
            {
                diagnosis = new Diagnosis
                {
                    Id = (int) item["DiagnosisId"],
                    Title = (string) item["Title"]
                };
            }

            return diagnosis;
        }

        public IReadOnlyCollection<Diagnosis> GetAll()
        {
            var allDiagnoses = new List<Diagnosis>();

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_ALL_DIAGNOSIS)
                .ExecuteReader();

            foreach (var item in reader)
            {
                allDiagnoses.Add(new Diagnosis
                {
                    Id = (int)item["DiagnosisId"],
                    Title = (string)item["Title"]
                });
            }

            return allDiagnoses;
        }
    }
}
