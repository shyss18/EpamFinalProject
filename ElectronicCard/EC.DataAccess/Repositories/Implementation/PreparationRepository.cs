using EC.Common.Helpers;
using EC.Common.Helpers.Interface;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using System.Collections.Generic;
using System.Data;

namespace EC.DataAccess.Repositories.Implementation
{
    public class PreparationRepository : IPreparationRepository
    {
        private readonly ISqlFactory _query;

        public PreparationRepository(ISqlFactory query)
        {
            _query = query;
        }

        public void Create(Preparation item)
        {
            var nameParameter = _query.CreateParameter("title", item.Title, DbType.String);
            var descParameter = _query.CreateParameter("description", item.Description, DbType.String);
            var timeParameter = _query.CreateParameter("timeUse", item.TimeUse, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.CREATE_PREPARATION)
                .AddParameters(nameParameter, descParameter, timeParameter)
                .ExecuteQuery();
        }

        public void Update(Preparation item)
        {
            var idParameter = _query.CreateParameter("id", item.Id, DbType.Int32);
            var nameParameter = _query.CreateParameter("title", item.Title, DbType.String);
            var descParameter = _query.CreateParameter("description", item.Description, DbType.String);
            var timeParameter = _query.CreateParameter("timeUse", item.TimeUse, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.UPDATE_PREPARATION)
                .AddParameters(idParameter, nameParameter, descParameter, timeParameter)
                .ExecuteQuery();
        }

        public void Delete(int? id)
        {
            var idParameter = _query.CreateParameter("id", id, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.DELETE_PREPARATION)
                .AddParameters(idParameter)
                .ExecuteQuery();
        }

        public Preparation GetById(int? id)
        {
            Preparation preparation = null;

            var idParameter = _query.CreateParameter("id", id, DbType.Int32);

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_PREPARATION_BY_ID)
                .AddParameters(idParameter)
                .ExecuteReader();

            foreach (var item in reader)
            {
                preparation = new Preparation
                {
                    Id = (int)item["Id"],
                    Title = (string)item["Title"],
                    Description = (string)item["Description"],
                    TimeUse = (int)item["TimeUse"]
                };
            }

            return preparation;
        }

        public IReadOnlyCollection<Preparation> GetAll()
        {
            List<Preparation> allPreparations = new List<Preparation>();

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_ALL_PREPARATION)
                .ExecuteReader();

            foreach (var item in reader)
            {
                allPreparations.Add(new Preparation
                {
                    Id = (int)item["Id"],
                    Title = (string)item["Title"],
                    Description = (string)item["Description"],
                    TimeUse = (int)item["TimeUse"]
                });
            }

            return allPreparations;
        }
    }
}
