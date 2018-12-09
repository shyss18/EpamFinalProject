using System.Data;

namespace EC.DataAccess.Helpers.Interface
{
    public interface ICreateParameterHelper
    {
        IDataParameter CreateParameter(string name, object value, DbType type);
    }
}
