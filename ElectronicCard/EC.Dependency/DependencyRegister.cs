using EC.BusinessLogic.Dependency;
using EC.Common.Dependency;
using EC.DataAccess.Dependency;
using StructureMap;

namespace EC.Dependency
{
    public class DependencyRegister : Registry
    {
        public DependencyRegister()
        {
            Scan(scan =>
            {
                scan.AssemblyContainingType<DataRegistry>();
                scan.AssemblyContainingType<ServiceRegistry>();
                scan.AssemblyContainingType<CommonRegistry>();

                scan.LookForRegistries();
            });
        }
    }
}
