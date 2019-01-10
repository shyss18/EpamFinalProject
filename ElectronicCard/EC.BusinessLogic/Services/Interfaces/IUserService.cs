using EC.Entities.Entities;
using System.Collections.Generic;

namespace EC.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User user);
        void UpdateUser(User user);
        bool DeleteUser(int? id);
        User GetUserById(int? id);
        User GetUserByLogin(string login);
        IReadOnlyCollection<User> GetAllUsers();
        IReadOnlyCollection<Patient> GetAllPatients();
        IReadOnlyCollection<Doctor> GetAllDoctors();
        IReadOnlyCollection<Patient> GetUserPatients(int? userId);
    }
}
