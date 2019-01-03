using EC.Entities.Entities;
using System.Collections.Generic;

namespace EC.BusinessLogic.Services.Interfaces
{
    public interface IDoctorService
    {
        void CreateDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(int? id);
        User GetDoctorById(int? id);
        IReadOnlyCollection<Doctor> GetAllDoctors();
    }
}
