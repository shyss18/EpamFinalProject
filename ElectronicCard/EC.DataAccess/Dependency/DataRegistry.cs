using EC.DataAccess.Helpers.Implementation;
using EC.DataAccess.Helpers.Interface;
using EC.DataAccess.Repositories.Implementation;
using EC.DataAccess.Repositories.Interfaces;
using StructureMap;

namespace EC.DataAccess.Dependency
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<ICreateQuery>().Singleton().Use<CreateQuery>();

            For<IHelper>().Use<Helper>();
            For<IPhoneRepository>().Use<PhoneRepository>();
            For<IRoleRepository>().Use<RoleRepository>();
        }
    }
}
