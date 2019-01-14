using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EC.BusinessLogic.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(User user)
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
                    UserId = user.Id,
                    Login = user.Login,
                    Password = user.Password,
                    Email = user.Email,
                    IsDoctor = user.IsDoctor,
                    Roles = user.Roles,
                    PhoneNumbers = user.PhoneNumbers,
                    FirstName = user.Doctor.FirstName,
                    MiddleName = user.Doctor.MiddleName,
                    LastName = user.Doctor.LastName,
                    Position = user.Doctor.Position
                };

                if (user.Doctor.Patients != null)
                {
                    doctor.Patients = user.Doctor.Patients;
                }

                if (user.Photo != null)
                {
                    doctor.Photo = user.Photo;
                }

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
                    Roles = user.Roles,
                    PhoneNumbers = user.PhoneNumbers,
                    FirstName = user.Patient.FirstName,
                    MiddleName = user.Patient.MiddleName,
                    LastName = user.Patient.LastName,
                    PlaceWork = user.Patient.PlaceWork,
                    DateBirth = user.Patient.DateBirth
                };

                if (user.Patient.Doctors != null)
                {
                    patient.Doctors = user.Patient.Doctors;
                }

                if (user.Photo != null)
                {
                    patient.Photo = user.Photo;
                }

                _userRepository.Create(patient);
            }
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

                if (user.Photo != null)
                {
                    doctor.Photo = user.Photo;
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

                if (user.Photo != null)
                {
                    patient.Photo = user.Photo;
                }

                _userRepository.Update(patient);
            }
        }

        public bool DeleteUser(int? id)
        {
            try
            {
                if (id == null || id <= 0)
                {
                    return false;
                }

                _userRepository.Delete(id);

                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public User GetUserById(int? id)
        {
            return id == null || id <= 0 ? null : _userRepository.GetById(id);
        }

        public User GetUserByLogin(string login)
        {
            return login == null ? null : _userRepository.GetUserByLogin(login);
        }

        public IReadOnlyCollection<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public IReadOnlyCollection<Patient> GetAllPatients()
        {
            return _userRepository.GetAllPatients();
        }

        public IReadOnlyCollection<Doctor> GetAllDoctors()
        {
            return _userRepository.GetAllDoctors();
        }

        public IReadOnlyCollection<Patient> GetUserPatients(int? userId)
        {
            return userId == null || userId <= 0 ? null : _userRepository.GetUserPatients(userId);
        }
    }
}
