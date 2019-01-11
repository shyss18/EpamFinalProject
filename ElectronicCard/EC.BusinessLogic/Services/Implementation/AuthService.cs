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
                var doctor = new Doctor
                {
                    Id = user.Id,
                    UserId = user.Id,
                    Login = user.Login,
                    Password = user.Password,
                    Email = user.Email,
                    IsDoctor = user.IsDoctor,
                    Roles = new List<Role>
                    {
                        new Role{Id = 2}
                    },
                    PhoneNumbers = user.PhoneNumbers,
                    FirstName = user.Doctor.FirstName,
                    MiddleName = user.Doctor.MiddleName,
                    LastName = user.Doctor.LastName,
                    Position = user.Doctor.Position
                };

                _userRepository.Create(doctor);
            }
            else
            {
                var patient = new Patient
                {
                    Id = user.Id,
                    UserId = user.Id,
                    Login = user.Login,
                    Password = user.Password,
                    Email = user.Email,
                    IsDoctor = user.IsDoctor,
                    Roles = new List<Role>
                    {
                        new Role {Id = 1}
                    },
                    PhoneNumbers = user.PhoneNumbers,
                    FirstName = user.Patient.FirstName,
                    MiddleName = user.Patient.MiddleName,
                    LastName = user.Patient.LastName,
                    PlaceWork = user.Patient.PlaceWork,
                    DateBirth = user.Patient.DateBirth
                };

                _userRepository.Create(patient);
            }
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public User GetUserByLogin(string login)
        {
            return login == null ? null : _userRepository.GetUserByLogin(login);
        }

        public User GetUserByEmail(string email)
        {
            return email == null ? null : _userRepository.GetUserByEmail(email);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                return;
            }

            DeleteCookie();
            CreateCookie(user);

            if (user.IsDoctor)
            {
                var doctor = new Doctor
                {
                    Id = user.Id,
                    UserId = user.Id,
                    Login = user.Login,
                    IsDoctor = user.IsDoctor,
                    Password = user.Password,
                    Email = user.Email,
                    Roles = user.Roles,
                    PhoneNumbers = user.PhoneNumbers,
                    FirstName = user.Doctor.FirstName,
                    MiddleName = user.Doctor.MiddleName,
                    LastName = user.Doctor.LastName,
                    Position = user.Doctor.Position
                };

                if (user.Doctor.Patients != null && user.Doctor.Patients.Count > 0)
                {
                    doctor.Patients = user.Doctor.Patients;
                }

                _userRepository.Update(doctor);
            }
            else
            {
                var patient = new Patient
                {
                    Id = user.Id,
                    UserId = user.Id,
                    Login = user.Login,
                    Password = user.Password,
                    IsDoctor = user.IsDoctor,
                    Email = user.Email,
                    Roles = user.Roles,
                    PhoneNumbers = user.PhoneNumbers,
                    FirstName = user.Patient.FirstName,
                    MiddleName = user.Patient.MiddleName,
                    LastName = user.Patient.LastName,
                    PlaceWork = user.Patient.PlaceWork,
                    DateBirth = user.Patient.DateBirth
                };

                if (user.Patient.Doctors != null && user.Patient.Doctors.Count > 0)
                {
                    patient.Doctors = user.Patient.Doctors;
                }
                
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
