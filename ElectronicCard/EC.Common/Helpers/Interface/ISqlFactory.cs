using System.Collections.Generic;
using System.Data;

namespace EC.Common.Helpers.Interface
{
    public interface ISqlFactory
    {
        ISqlFactory CreateConnection();
        ISqlFactory CreateCommand(string name);
        ISqlFactory AddParameters(params IDataParameter[] parameters);
        IEnumerable<IDataRecord> ExecuteReader();
        IDataParameter CreateParameter(string name, object value, DbType type);
        void ExecuteQuery();
        int ExecuteScalar();
    }
}
