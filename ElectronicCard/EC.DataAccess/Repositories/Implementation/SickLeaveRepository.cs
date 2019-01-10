using EC.Common.Helpers;
using EC.Common.Helpers.Interface;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using System.Collections.Generic;
using System.Data;

namespace EC.DataAccess.Repositories.Implementation
{
    public class SickLeaveRepository : ISickLeaveRepository
    {
        private readonly ISqlFactory _query;

        public SickLeaveRepository(ISqlFactory query)
        {
            _query = query;
        }

        public void Create(SickLeave item)
        {
            var isGiveParameter = _query.CreateParameter("isGive", item.IsGive, DbType.Boolean);
            var numberParameter = _query.CreateParameter("number", item.Number, DbType.Int32);
            var periodParameter = _query.CreateParameter("periodAction", item.PeriodAction, DbType.Int32);
            var diagnosisParameter = _query.CreateParameter("diagnosisId", item.DiagnosisId, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.CREATE_SICKLEAVE)
                .AddParameters(isGiveParameter, numberParameter, periodParameter, diagnosisParameter)
                .ExecuteQuery();
        }

        public void Update(SickLeave item)
        {
            var idParameter = _query.CreateParameter("id", item.Id, DbType.Int32);
            var isGiveParameter = _query.CreateParameter("isGive", item.IsGive, DbType.Boolean);
            var numberParameter = _query.CreateParameter("number", item.Number, DbType.Int32);
            var periodParameter = _query.CreateParameter("periodAction", item.PeriodAction, DbType.Int32);
            var diagnosisParameter = _query.CreateParameter("diagnosisId", item.DiagnosisId, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.UPDATE_SICKLEAVE)
                .AddParameters(idParameter, isGiveParameter, numberParameter, periodParameter, diagnosisParameter)
                .ExecuteQuery();
        }

        public void Delete(int? id)
        {
            var idParameter = _query.CreateParameter("id", id, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.DELETE_SICKLEAVE)
                .AddParameters(idParameter)
                .ExecuteQuery();
        }

        public SickLeave GetById(int? id)
        {
            var idParameter = _query.CreateParameter("id", id, DbType.Int32);

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_SICKLEAVE_BY_ID)
                .AddParameters(idParameter)
                .ExecuteReader();

            SickLeave sickLeave = null;

            foreach (var item in reader)
            {
                sickLeave = new SickLeave
                {
                    Id = (int)item["SickLeaveId"],
                    IsGive = (bool)item["IsGive"],
                    Number = (int)item["Number"],
                    PeriodAction = (int)item["PeriodAction"],
                    DiagnosisId = item["DiagnosisId"] as int? ?? default(int)
                };

                if (sickLeave.DiagnosisId != default(int))
                {
                    sickLeave.DiagnosisId = (int)item["DiagnosisId"];
                    sickLeave.Diagnosis = new Diagnosis
                    {
                        Id = (int)item["DiagnosisId"],
                        Title = (string)item["Title"]
                    };
                }
            }

            return sickLeave;
        }

        public IReadOnlyCollection<SickLeave> GetAll()
        {
            var allSickLeaves = new List<SickLeave>();

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_ALL_SICKLEAVES)
                .ExecuteReader();

            foreach (var item in reader)
            {
                var sickLeave = new SickLeave
                {
                    Id = (int) item["SickLeaveId"],
                    IsGive = (bool) item["IsGive"],
                    Number = (int) item["Number"],
                    PeriodAction = (int) item["PeriodAction"],
                    DiagnosisId = item["DiagnosisId"] as int? ?? default(int)
                };
                
                if (sickLeave.DiagnosisId != default(int))
                {
                    sickLeave.DiagnosisId = (int) item["DiagnosisId"];
                    sickLeave.Diagnosis = new Diagnosis
                    {
                        Id = (int) item["DiagnosisId"],
                        Title = (string) item["Title"]
                    };
                }

                allSickLeaves.Add(sickLeave);
            }

            return allSickLeaves;
        }
    }
}
