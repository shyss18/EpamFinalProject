using EC.Entities.Entities;
using System.Linq;
using System.Security.Principal;

namespace EC.BusinessLogic.Auth
{
    public class UserPrincipal : IPrincipal
    {
        public IIdentity Identity { get; }

        public User User { get; set; }

        public UserPrincipal(User user)
        {
            User = user;
            Identity = new GenericIdentity(user.Login);
        }

        public bool IsInRole(string role)
        {
            return User.Roles.Select(r => r.Name).Contains(role);
        }
    }
}
