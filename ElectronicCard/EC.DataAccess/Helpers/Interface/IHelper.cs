using System.Data;

namespace EC.DataAccess.Helpers.Interface
{
    public interface IHelper
    {
        IHelper CreateParameter(string name);
        IHelper WithValue(object value);
        IHelper WithType(DbType type);
        IDataParameter Create();
    }
}
