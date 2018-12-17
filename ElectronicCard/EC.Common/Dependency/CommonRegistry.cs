using EC.Common.Logger;
using StructureMap;

namespace EC.Common.Dependency
{
    public class CommonRegistry : Registry
    {
        public CommonRegistry()
        {
            For<ICustomLogger>().Singleton().Use<CustomLogger>();
        }
    }
}
