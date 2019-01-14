using System.Collections.Generic;
using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        void AddPatientToDoctor(int? patientId, int? doctorId);
        IReadOnlyCollection<Patient> GetUserPatients(int? userId);
        IReadOnlyCollection<Patient> GetAllPatients();
        IReadOnlyCollection<Doctor> GetAllDoctors();
        User GetUserByLogin(string login);
        User GetUserByEmail(string email);
    }
}
