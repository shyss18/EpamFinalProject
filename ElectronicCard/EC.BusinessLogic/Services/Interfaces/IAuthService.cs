using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Interfaces
{
    public interface IAuthService
    {
        bool SignIn(string login, string password);
        void SignUp(User user);
        void SignOut();
        User GetUserByLogin(string login);
        void UpdateUser(User user);
        User GetUserByEmail(string email);
        string GetVerificationCode();
        void EditVerificationCode(string code);
    }
}
