using EC.BusinessLogic.Services.Implementation;
using EC.BusinessLogic.Services.Interfaces;
using StructureMap;

namespace EC.BusinessLogic.Dependency
{
    public class ServiceRegistry: Registry
    {
        public ServiceRegistry()
        {
            For<IPhoneService>().Use<PhoneService>();
        }
    }
}
