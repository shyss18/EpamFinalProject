using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;

namespace EC.BusinessLogic.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool SignIn(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            if (IsValidUser(email, password))
            {
                var user = _userRepository.GetUserByEmail(email);

                var data = JsonConvert.SerializeObject(user);

                var ticket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(10),
                    false, data);

                var encryptTicket = FormsAuthentication.Encrypt(ticket);

                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);

                HttpContext.Current.Response.Cookies.Add(cookie);

                return true;
            }

            return false;
        }

        public void SignUp(User user)
        {
            if (user.IsDoctor)
            {
                user.Roles = new List<Role>
                {
                    new Role{Id = 2}
                };
            }
            else
            {
                user.Roles = new List<Role>
                {
                    new Role{Id = 1}
                };
            }

            _userRepository.Create(user);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        private bool IsValidUser(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);

            return user != null && user.Password == password;
        }
    }
}
