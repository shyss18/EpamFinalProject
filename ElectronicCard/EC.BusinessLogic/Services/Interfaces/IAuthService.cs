using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Interfaces
{
    public interface IAuthService
    {
        bool SignIn(string login, string password);
        void SignUp(User user);
        void SignOut();
        User GetUserByLogin(string email);
        void UpdateUser(User user);
    }
}
