using System.Data;

namespace EC.DataAccess.Helpers.Interface
{
    public interface ICreateQuery
    {
        ICreateQuery CreateConnection();
        ICreateQuery CreateCommand(string name);
        ICreateQuery AddParameters(params IDataParameter[] parameters);
        IDataReader ExecuteReader();
        void ExecuteQuery();
        int ExecuteScalar();
    }
}
