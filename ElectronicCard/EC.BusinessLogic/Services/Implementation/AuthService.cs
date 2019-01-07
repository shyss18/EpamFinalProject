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

        public bool SignIn(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            if (IsValidUser(login, password))
            {
                var user = _userRepository.GetUserByLogin(login);

                CreateCookie(user);

                return true;
            }

            return false;
        }

        private bool IsValidUser(string login, string password)
        {
            var user = _userRepository.GetUserByLogin(login);

            return user != null && user.Password == password;
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

        public User GetUserByLogin(string login)
        {
            return login == null ? null : _userRepository.GetUserByLogin(login);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                return;
            }

            if (user.IsDoctor)
            {
                var doctor = new Doctor
                {
                    Id = user.Id,
                    Login = user.Login,
                    Email = user.Email,
                    IsDoctor = user.IsDoctor,
                    Password = user.Password,
                    FirstName = user.Doctor.FirstName,
                    MiddleName = user.Doctor.MiddleName,
                    LastName = user.Doctor.LastName,
                    Position = user.Doctor.Position,
                    Roles = user.Roles,
                    Records = user.Records,
                    PhoneNumbers = user.PhoneNumbers,
                    Patients = user.Doctor.Patients,
                    Photo = user.Photo
                };

                DeleteCookie();
                CreateCookie(user);

                _userRepository.Update(doctor);
            }
            else
            {
                var patient = new Patient
                {
                    Id = user.Id,
                    Login = user.Login,
                    Email = user.Email,
                    IsDoctor = user.IsDoctor,
                    Password = user.Password,
                    FirstName = user.Patient.FirstName,
                    MiddleName = user.Patient.MiddleName,
                    LastName = user.Patient.LastName,
                    PlaceWork = user.Patient.PlaceWork,
                    DateBirth = user.Patient.DateBirth,
                    Roles = user.Roles,
                    Records = user.Records,
                    PhoneNumbers = user.PhoneNumbers,
                    Doctors = user.Patient.Doctors,
                    Photo = user.Photo
                };

                DeleteCookie();
                CreateCookie(user);
                _userRepository.Update(patient);
            }
        }

        private static void DeleteCookie()
        {
            if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                var deleteCookie = new HttpCookie(FormsAuthentication.FormsCookieName)
                {
                    Expires = DateTime.Now.AddDays(-1)
                };

                HttpContext.Current.Response.Cookies.Add(deleteCookie);
            }
        }

        private static void CreateCookie(User user)
        {
            var serialize = new SerializeModel
            {
                Login = user.Login,
                Roles = user.Roles
            };

            var data = JsonConvert.SerializeObject(serialize);

            var ticket = new FormsAuthenticationTicket(1, user.Login, DateTime.Now, DateTime.Now.AddMinutes(10),
                false, data);

            var encryptTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);

            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
