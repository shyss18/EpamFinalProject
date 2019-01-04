using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Interfaces
{
    public interface IAuthService
    {
        bool SignIn(string email, string password);
        void SignUp(User user);
    }
}
