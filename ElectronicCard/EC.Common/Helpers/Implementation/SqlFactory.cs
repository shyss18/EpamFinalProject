using EC.Common.Helpers.Interface;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EC.Common.Helpers.Implementation
{
    public class SqlFactory : ISqlFactory
    {
        private IDbCommand _sqlCommand;
        private IDbConnection _sqlConnection;

        public ISqlFactory CreateConnection()
        {
            _sqlConnection = new SqlConnection(DbConstants.ConnectionString);

            return this;
        }

        public ISqlFactory CreateCommand(string name)
        {
            _sqlCommand = new SqlCommand(name, _sqlConnection as SqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            return this;
        }

        public ISqlFactory AddParameters(params IDataParameter[] parameters)
        {
            foreach (var item in parameters)
            {
                _sqlCommand.Parameters.Add(item);
            }

            return this;
        }

        public void ExecuteQuery()
        {
            using (_sqlConnection)
            {
                _sqlConnection.Open();

                _sqlCommand.ExecuteNonQuery();
            }
        }

        public IEnumerable<IDataRecord> ExecuteReader()
        {
            using (_sqlConnection)
            {
                _sqlConnection.Open();

                using (var read = _sqlCommand.ExecuteReader())
                {
                    while (read.Read())
                    {
                        yield return read;
                    }
                }
            }
        }

        public int ExecuteScalar()
        {
            int id = default(int);

            using (_sqlConnection)
            {
                _sqlConnection.Open();

                id = (int)_sqlCommand.ExecuteScalar();
            }

            return id;
        }

        public IDataParameter CreateParameter(string name, object value, DbType type)
        {
            name = name.StartsWith("@") ? name : "@" + name;

            var parameter = new SqlParameter
            {
                ParameterName = name,
                Value = value,
                DbType = type
            };

            return parameter;
        }
    }
}
