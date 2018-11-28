using EC.BusinessLogic.Dependency;
using EC.DataAccess.Dependency;
using StructureMap;

namespace EC.Dependency
{
    public class DependencyRegister : Registry
    {
        public DependencyRegister()
        {
            Scan(d =>
            {
                d.AssemblyContainingType<DataRegistry>();
                d.AssemblyContainingType<ServiceRegistry>();

                d.WithDefaultConventions();
                d.LookForRegistries();
            });
        }
    }
}
