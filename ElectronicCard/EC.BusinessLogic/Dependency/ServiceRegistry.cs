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
            For<IRoleService>().Use<RoleService>();
            For<IPreparationService>().Use<PreparationService>();
            For<IProcedureService>().Use<ProcedureService>();
            For<IAdvertisingService>().Use<AdvertisingService>();
            For<ISickLeaveService>().Use<SickLeaveService>();
            For<IDiagnosisService>().Use<DiagnosisService>();
            For<IRecordService>().Use<RecordService>();
            For<IPhotoService>().Use<PhotoService>();
            For<IAuthService>().Use<AuthService>();
            For<IUserService>().Use<UserService>();
        }
    }
}
