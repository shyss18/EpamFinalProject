using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.DataAccess.Helpers.Interface;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;

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
            var isGiveParameter = _query.CreateParameter("isGive", item.IsGive, DbType.Binary);
            var numberParameter = _query.CreateParameter("number", item.Number, DbType.Int32);
            var periodParameter = _query.CreateParameter("periodAction", item.PeriodAction, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.CREATE_SICKLEAVE)
                .AddParameters(isGiveParameter, numberParameter, periodParameter)
                .ExecuteQuery();
        }

        public void Update(SickLeave item)
        {
            var idParameter = _query.CreateParameter("id", item.Id, DbType.Int32);
            var isGiveParameter = _query.CreateParameter("isGive", item.IsGive, DbType.Binary);
            var numberParameter = _query.CreateParameter("number", item.Number, DbType.Int32);
            var periodParameter = _query.CreateParameter("periodAction", item.PeriodAction, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.UPDATE_SICKLEAVE)
                .AddParameters(idParameter, isGiveParameter, numberParameter, periodParameter)
                .ExecuteQuery();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public SickLeave GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<SickLeave> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
