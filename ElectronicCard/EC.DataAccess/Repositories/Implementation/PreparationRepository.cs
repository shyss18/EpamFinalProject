using System.Collections.Generic;
using System.Data;
using EC.DataAccess.Helpers.Interface;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Implementation
{
    public class PreparationRepository : IPreparationRepository
    {
        private readonly ICreateQuery _query;
        private readonly ICreateParameterHelper _helper;

        public PreparationRepository(ICreateQuery query, ICreateParameterHelper helper)
        {
            _query = query;
            _helper = helper;
        }

        public void Create(Preparation item)
        {
            var nameParameter = _helper.CreateParameter("name", item.Title, DbType.String);
            var descParameter = _helper.CreateParameter("description", item.Description, DbType.String);
            var timeParameter = _helper.CreateParameter("timeUse", item.TimeUse, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.CREATE_PREPARATION)
                .AddParameters(nameParameter, descParameter, timeParameter)
                .ExecuteQuery();
        }

        public void Update(Preparation item)
        {
            var nameParameter = _helper.CreateParameter("name", item.Title, DbType.String);
            var descParameter = _helper.CreateParameter("description", item.Description, DbType.String);
            var timeParameter = _helper.CreateParameter("timeUse", item.TimeUse, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.UPDATE_PREPARATION)
                .AddParameters(nameParameter, descParameter, timeParameter)
                .ExecuteQuery();
        }

        public void Delete(int? id)
        {
            var idParameter = _helper.CreateParameter("id", id, DbType.Int32);

            _query.CreateConnection()
                .CreateCommand(DbConstants.DELETE_PREPARATION)
                .AddParameters(idParameter)
                .ExecuteQuery();
        }

        public Preparation GetById(int? id)
        {
            Preparation preparation = null;

            var idParameter = _helper.CreateParameter("id", id, DbType.Int32);

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_PREPARATION_BY_ID)
                .AddParameters(idParameter)
                .ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    preparation = new Preparation
                    {
                        Id = (int)reader["Id"],
                        Title = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        TimeUse = (int)reader["TimeUse"]
                    };
                }

                reader.Close();
            }

            return preparation;
        }

        public IReadOnlyCollection<Preparation> GetAll()
        {
            List<Preparation> allPreparations = new List<Preparation>();

            var reader = _query.CreateConnection()
                .CreateCommand(DbConstants.GET_ALL_PREPARATION)
                .ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    var procedure = new Preparation
                    {
                        Id = (int)reader["Id"],
                        Title = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        TimeUse = (int)reader["TimeUse"]
                    };

                    allPreparations.Add(procedure);
                }

                reader.Close();
            }

            return allPreparations;
        }
    }
}
