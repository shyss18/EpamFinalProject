using System.Collections.Generic;
using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IReadOnlyCollection<Patient> GetAllPatients();
        IReadOnlyCollection<Doctor> GetAllDoctors();
        User GetUserByEmail(string email);
    }
}
