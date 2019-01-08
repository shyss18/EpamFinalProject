using EC.Common.Helpers;
using EC.Common.Helpers.Interface;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using DbConstants = EC.Common.Helpers.DbConstants;

namespace EC.DataAccess.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlFactory _factory;
        private readonly IPhoneRepository _phoneRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPhotoRepository _photoRepository;

        public UserRepository(ISqlFactory factory, IPhoneRepository phoneRepository, IRoleRepository roleRepository, IPhotoRepository photoRepository)
        {
            _factory = factory;
            _phoneRepository = phoneRepository;
            _roleRepository = roleRepository;
            _photoRepository = photoRepository;
        }

        public void Create(User item)
        {
            var loginParameter = _factory.CreateParameter("login", item.Login, DbType.String);
            var passwordParameter = _factory.CreateParameter("password", item.Password, DbType.String);
            var emailParameter = _factory.CreateParameter("email", item.Email, DbType.String);
            var isDoctorParameter = _factory.CreateParameter("isDoctor", item.IsDoctor, DbType.Boolean);

            switch (item)
            {
                case Patient patient:
                    {
                        var firstNameParameter = _factory.CreateParameter("firstName", patient.FirstName, DbType.String);
                        var middleNameParameter = _factory.CreateParameter("middleName", patient.MiddleName, DbType.String);
                        var lastNameParameter = _factory.CreateParameter("lastName", patient.LastName, DbType.String);
                        var dateBirthParameter = _factory.CreateParameter("dateBirth", patient.DateBirth, DbType.Date);
                        var workParameter = _factory.CreateParameter("work", patient.PlaceWork, DbType.String);

                        var id = _factory.CreateConnection()
                            .CreateCommand(DbConstants.CREATE_USER)
                            .AddParameters(loginParameter, passwordParameter, emailParameter, isDoctorParameter, firstNameParameter, middleNameParameter, lastNameParameter, dateBirthParameter, workParameter)
                            .ExecuteScalar();

                        if (patient.PhoneNumbers.Count > 0)
                        {
                            foreach (var phoneNumber in patient.PhoneNumbers)
                            {
                                phoneNumber.UserId = id;
                                _phoneRepository.Create(phoneNumber);
                            }
                        }

                        foreach (var role in patient.Roles)
                        {
                            _roleRepository.AddRoleToUser(id, role.Id);
                        }

                        if (patient.Photo != null)
                        {
                            patient.Photo.UserId = id;
                            _photoRepository.Create(patient.Photo);
                        }

                        if (patient.Doctors != null)
                        {
                            foreach (var doctors in patient.Doctors)
                            {
                                AddPatientToDoctor(id, doctors.UserId);
                            }
                        }

                        break;
                    }
                case Doctor doctor:
                    {
                        var firstNameParameter = _factory.CreateParameter("firstName", doctor.FirstName, DbType.String);
                        var middleNameParameter = _factory.CreateParameter("middleName", doctor.MiddleName, DbType.String);
                        var lastNameParameter = _factory.CreateParameter("lastName", doctor.LastName, DbType.String);
                        var workParameter = _factory.CreateParameter("work", doctor.Position, DbType.String);

                        var id = _factory.CreateConnection()
                            .CreateCommand(DbConstants.CREATE_USER)
                            .AddParameters(loginParameter, passwordParameter, emailParameter, isDoctorParameter, firstNameParameter, middleNameParameter, lastNameParameter, workParameter)
                            .ExecuteScalar();

                        if (doctor.PhoneNumbers.Count > 0)
                        {
                            foreach (var phoneNumber in doctor.PhoneNumbers)
                            {
                                phoneNumber.UserId = id;
                                _phoneRepository.Create(phoneNumber);
                            }
                        }

                        foreach (var role in doctor.Roles)
                        {
                            _roleRepository.AddRoleToUser(id, role.Id);
                        }

                        if (doctor.Photo != null)
                        {
                            doctor.Photo.UserId = id;
                            _photoRepository.Create(doctor.Photo);
                        }

                        if (doctor.Patients != null)
                        {
                            foreach (var patient in doctor.Patients)
                            {
                                AddPatientToDoctor(patient.UserId, id);
                            }
                        }

                        break;
                    }
                default:
                    throw new InvalidCastException("Не удалось преобразовать ни к одному из типов: Patient, Doctor");
            }
        }

        public void Update(User item)
        {
            var idParameter = _factory.CreateParameter("id", item.Id, DbType.Int32);
            var loginParameter = _factory.CreateParameter("login", item.Login, DbType.String);
            var passwordParameter = _factory.CreateParameter("password", item.Password, DbType.String);
            var emailParameter = _factory.CreateParameter("email", item.Email, DbType.String);
            var isDoctorParameter = _factory.CreateParameter("isDoctor", item.IsDoctor, DbType.Boolean);

            switch (item)
            {
                case Patient patient:
                    {
                        var firstNameParameter = _factory.CreateParameter("firstName", patient.FirstName, DbType.String);
                        var middleNameParameter = _factory.CreateParameter("middleName", patient.MiddleName, DbType.String);
                        var lastNameParameter = _factory.CreateParameter("lastName", patient.LastName, DbType.String);
                        var dateBirthParameter = _factory.CreateParameter("dateBirth", patient.DateBirth, DbType.Date);
                        var workParameter = _factory.CreateParameter("work", patient.PlaceWork, DbType.String);

                        _factory.CreateConnection()
                            .CreateCommand(DbConstants.UPDATE_USER)
                            .AddParameters(idParameter, loginParameter, passwordParameter, emailParameter, isDoctorParameter, firstNameParameter, middleNameParameter, lastNameParameter, dateBirthParameter, workParameter)
                            .ExecuteQuery();

                        if (patient.Roles != null)
                        {
                            _roleRepository.DeleteUserRoles(patient.Id);

                            foreach (var role in patient.Roles)
                            {
                                _roleRepository.AddRoleToUser(patient.Id, role.Id);
                            }
                        }

                        if (patient.Doctors != null)
                        {
                            DeleteUserDoctors(patient.Id);

                            foreach (var doctor in patient.Doctors)
                            {
                                AddPatientToDoctor(patient.Id, doctor.UserId);
                            }
                        }


                        break;
                    }
                case Doctor doctor:
                    {
                        var firstNameParameter = _factory.CreateParameter("firstName", doctor.FirstName, DbType.String);
                        var middleNameParameter = _factory.CreateParameter("middleName", doctor.MiddleName, DbType.String);
                        var lastNameParameter = _factory.CreateParameter("lastName", doctor.LastName, DbType.String);
                        var workParameter = _factory.CreateParameter("work", doctor.Position, DbType.String);

                        _factory.CreateConnection()
                            .CreateCommand(DbConstants.UPDATE_USER)
                            .AddParameters(idParameter, loginParameter, passwordParameter, emailParameter, isDoctorParameter, firstNameParameter, middleNameParameter, lastNameParameter, workParameter)
                            .ExecuteQuery();

                        if (doctor.Roles != null)
                        {
                            _roleRepository.DeleteUserRoles(doctor.Id);

                            foreach (var role in doctor.Roles)
                            {
                                _roleRepository.AddRoleToUser(doctor.Id, role.Id);
                            }
                        }

                        if (doctor.Patients != null)
                        {
                            DeleteUserPatients(doctor.Id);

                            foreach (var patient in doctor.Patients)
                            {
                                AddPatientToDoctor(patient.UserId, doctor.UserId);
                            }
                        }

                        break;
                    }
                default:
                    throw new InvalidCastException("Не удалось преобразовать ни к одному из типов: Patient, Doctor");
            }

        }

        public void Delete(int? id)
        {
            var idParameter = _factory.CreateParameter("id", id, DbType.Int32);

            _factory.CreateConnection()
                .CreateCommand(DbConstants.DELETE_USER)
                .AddParameters(idParameter)
                .ExecuteQuery();
        }

        public void AddPatientToDoctor(int? patientId, int? doctorId)
        {
            var patientParameter = _factory.CreateParameter("patientId", patientId, DbType.Int32);
            var doctorParameter = _factory.CreateParameter("doctorId", doctorId, DbType.Int32);

            _factory.CreateConnection()
                .CreateCommand(DbConstants.ADD_PATIENT_TO_DOCTOR)
                .AddParameters(patientParameter, doctorParameter)
                .ExecuteQuery();
        }

        public User GetById(int? id)
        {
            var idParameter = _factory.CreateParameter("id", id, DbType.Int32);

            var reader = _factory.CreateConnection()
                .CreateCommand(DbConstants.GET_USER_BY_ID)
                .AddParameters(idParameter)
                .ExecuteReader();

            User user = null;

            foreach (var item in reader)
            {
                user = new User
                {
                    Id = (int)item["Id"],
                    Login = (string)item["Login"],
                    Email = (string)item["Email"],
                    Password = (string)item["Password"],
                    IsDoctor = (bool)item["IsDoctor"],
                };

                user.Roles = _roleRepository.GetUserRoles(user.Id);
                user.PhoneNumbers = _phoneRepository.GetUserPhones(user.Id);
                user.Photo = _photoRepository.GetUserPhoto(user.Id);

                if (user.IsDoctor)
                {
                    user.DoctorId = (int)item["UserId"];

                    user.Doctor = new Doctor
                    {
                        Id = (int)item["UserId"],
                        FirstName = (string)item["FirstName"],
                        MiddleName = (string)item["MiddleName"],
                        LastName = (string)item["LastName"],
                        Position = (string)item["Position"],
                        Patients = GetUserPatients(user.Id)
                    };

                }
                else
                {
                    user.PatientId = (int)item["UserId"];

                    user.Patient = new Patient
                    {
                        UserId = (int)item["UserId"],
                        FirstName = (string)item["FirstName"],
                        MiddleName = (string)item["MiddleName"],
                        LastName = (string)item["LastName"],
                        DateBirth = (DateTime)item["DateBirth"],
                        PlaceWork = (string)item["PlaceWork"],
                        Doctors = GetUserDoctors(user.Id)
                    };
                }
            }

            return user;
        }

        public User GetUserByLogin(string login)
        {
            var loginParameter = _factory.CreateParameter("login", login, DbType.String);

            var reader = _factory.CreateConnection()
                .CreateCommand(DbConstants.GET_USER_BY_LOGIN)
                .AddParameters(loginParameter)
                .ExecuteReader();

            User user = null;

            foreach (var item in reader)
            {
                user = new User
                {
                    Id = (int)item["Id"],
                    Login = (string)item["Login"],
                    Email = (string)item["Email"],
                    Password = (string)item["Password"],
                    IsDoctor = (bool)item["IsDoctor"],
                };

                user.Roles = _roleRepository.GetUserRoles(user.Id);
                user.PhoneNumbers = _phoneRepository.GetUserPhones(user.Id);
                user.Photo = _photoRepository.GetUserPhoto(user.Id);

                if (user.IsDoctor)
                {
                    user.DoctorId = (int)item["UserId"];

                    user.Doctor = new Doctor
                    {
                        Id = (int)item["UserId"],
                        FirstName = (string)item["FirstName"],
                        MiddleName = (string)item["MiddleName"],
                        LastName = (string)item["LastName"],
                        Position = (string)item["Position"]
                    };
                }
                else
                {
                    user.PatientId = (int)item["UserId"];

                    user.Patient = new Patient
                    {
                        UserId = (int)item["UserId"],
                        FirstName = (string)item["FirstName"],
                        MiddleName = (string)item["MiddleName"],
                        LastName = (string)item["LastName"],
                        DateBirth = (DateTime)item["DateBirth"],
                        PlaceWork = (string)item["PlaceWork"]
                    };
                }
            }

            return user;
        }

        public IReadOnlyCollection<User> GetAll()
        {
            var allUsers = new List<User>();

            var reader = _factory.CreateConnection()
                .CreateCommand(DbConstants.GET_ALL_USERS)
                .ExecuteReader();

            foreach (var item in reader)
            {
                var user = new User
                {
                    Id = (int)item["Id"],
                    Login = (string)item["Login"],
                    Email = (string)item["Email"],
                    Password = (string)item["Password"],
                    IsDoctor = (bool)item["IsDoctor"],
                };

                user.Roles = _roleRepository.GetUserRoles(user.Id);
                user.PhoneNumbers = _phoneRepository.GetUserPhones(user.Id);
                user.Photo = _photoRepository.GetUserPhoto(user.Id);

                if (user.IsDoctor)
                {
                    user.DoctorId = (int)item["UserId"];

                    user.Doctor = new Doctor
                    {
                        Id = (int)item["UserId"],
                        FirstName = (string)item["FirstName"],
                        MiddleName = (string)item["MiddleName"],
                        LastName = (string)item["LastName"],
                        Position = (string)item["Position"]
                    };
                }
                else
                {
                    user.PatientId = (int)item["PatientId"];

                    user.Patient = new Patient
                    {
                        UserId = (int)item["PatientId"],
                        FirstName = (string)item["PatientFirstName"],
                        MiddleName = (string)item["PatientMiddleName"],
                        LastName = (string)item["PatientLastName"],
                        DateBirth = (DateTime)item["DateBirth"],
                        PlaceWork = (string)item["PlaceWork"]
                    };
                }

                allUsers.Add(user);
            }

            return allUsers;
        }

        public IReadOnlyCollection<Patient> GetAllPatients()
        {
            var allPatients = new List<Patient>();

            var reader = _factory.CreateConnection()
                .CreateCommand(DbConstants.GET_ALL_PATIENTS)
                .ExecuteReader();

            foreach (var item in reader)
            {
                var patient = new Patient
                {
                    UserId = (int)item["UserId"],
                    Login = (string)item["Login"],
                    Email = (string)item["Email"],
                    Password = (string)item["Password"],
                    FirstName = (string)item["FirstName"],
                    MiddleName = (string)item["MiddleName"],
                    LastName = (string)item["LastName"],
                    DateBirth = (DateTime)item["DateBirth"],
                    PlaceWork = (string)item["PlaceWork"],
                };

                patient.Roles = _roleRepository.GetUserRoles(patient.UserId);
                patient.Photo = _photoRepository.GetUserPhoto(patient.UserId);
                patient.PhoneNumbers = _phoneRepository.GetUserPhones(patient.UserId);

                allPatients.Add(patient);
            }

            return allPatients;
        }

        public IReadOnlyCollection<Doctor> GetAllDoctors()
        {
            var allDoctors = new List<Doctor>();

            var reader = _factory.CreateConnection()
                .CreateCommand(DbConstants.GET_ALL_DOCTORS)
                .ExecuteReader();

            foreach (var item in reader)
            {
                var doctor = new Doctor
                {
                    UserId = (int)item["UserId"],
                    Login = (string)item["Login"],
                    Email = (string)item["Email"],
                    Password = (string)item["Password"],
                    FirstName = (string)item["FirstName"],
                    MiddleName = (string)item["MiddleName"],
                    LastName = (string)item["LastName"],
                    Position = (string)item["Position"],
                };

                doctor.Roles = _roleRepository.GetUserRoles(doctor.UserId);
                doctor.Photo = _photoRepository.GetUserPhoto(doctor.UserId);
                doctor.PhoneNumbers = _phoneRepository.GetUserPhones(doctor.UserId);

                allDoctors.Add(doctor);
            }

            return allDoctors;
        }

        public IReadOnlyCollection<Patient> GetUserPatients(int? userId)
        {
            var idParameter = _factory.CreateParameter("userId", userId, DbType.Int32);

            var reader = _factory.CreateConnection()
                .CreateCommand(DbConstants.GET_USER_PATIENTS)
                .AddParameters(idParameter)
                .ExecuteReader();

            var patients = new List<Patient>();

            foreach (var item in reader)
            {
                patients.Add(new Patient
                {
                    Id = (int)item["Id"],
                    Login = (string)item["Login"],
                    Email = (string)item["Email"],
                    Password = (string)item["Password"],
                    FirstName = (string)item["FirstName"],
                    MiddleName = (string)item["MiddleName"],
                    LastName = (string)item["LastName"],
                    DateBirth = (DateTime)item["DateBirth"],
                    PlaceWork = (string)item["PlaceWork"],
                });
            }

            return patients;
        }

        public IReadOnlyCollection<Doctor> GetUserDoctors(int? userId)
        {
            var idParameter = _factory.CreateParameter("userId", userId, DbType.Int32);

            var reader = _factory.CreateConnection()
                .CreateCommand(DbConstants.GET_USER_DOCTORS)
                .AddParameters(idParameter)
                .ExecuteReader();

            var doctors = new List<Doctor>();

            foreach (var item in reader)
            {
                doctors.Add(new Doctor
                {
                    UserId = (int)item["Id"],
                    Login = (string)item["Login"],
                    Email = (string)item["Email"],
                    Password = (string)item["Password"],
                    FirstName = (string)item["FirstName"],
                    MiddleName = (string)item["MiddleName"],
                    LastName = (string)item["LastName"],
                    Position = (string)item["Position"],
                });
            }

            return doctors;
        }

        private void DeleteUserDoctors(int? userId)
        {
            var idParameter = _factory.CreateParameter("userId", userId, DbType.Int32);

            _factory.CreateConnection()
                .CreateCommand(DbConstants.DELETE_USER_DOCTORS)
                .AddParameters(idParameter)
                .ExecuteQuery();
        }

        private void DeleteUserPatients(int? userId)
        {
            var idParameter = _factory.CreateParameter("userId", userId, DbType.Int32);

            _factory.CreateConnection()
                .CreateCommand(DbConstants.DELETE_USER_PATIENTS)
                .AddParameters(idParameter)
                .ExecuteQuery();
        }
    }
}
