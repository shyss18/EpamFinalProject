using System.Data;
using System.Data.SqlClient;
using EC.DataAccess.Helpers.Interface;

namespace EC.DataAccess.Helpers.Implementation
{
    internal class CreateParameterHelper : ICreateParameterHelper
    {
        public IDataParameter CreateParameter(string name, object value, DbType type)
        {
            name = name.StartsWith("@") ? name : "@" + name;

            var parameter = new SqlParameter
            {
                ParameterName = name,
                Value =  value,
                DbType = type
            };

            return parameter;
        }
    }
}
