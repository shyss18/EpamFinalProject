using System.Data;
using System.Data.SqlClient;
using EC.DataAccess.Helpers.Interface;

namespace EC.DataAccess.Helpers.Implementation
{
    internal class Helper : IHelper
    {
        private string _name;
        private object _value;
        private DbType _type;

        public IHelper CreateParameter(string name)
        {
            _name = name.StartsWith("@") ? name : "@" + name;

            return this;
        }

        public IHelper WithValue(object value)
        {
            _value = value;

            return this;
        }

        public IHelper WithType(DbType type)
        {
            _type = type;

            return this;
        }

        public IDataParameter Create()
        {
            return new SqlParameter
            {
                ParameterName = _name,
                Value = _value,
                DbType = _type
            };
        }
    }
}
