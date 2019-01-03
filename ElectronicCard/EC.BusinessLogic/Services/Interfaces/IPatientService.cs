using EC.Entities.Entities;
using System.Collections.Generic;

namespace EC.BusinessLogic.Services.Interfaces
{
    public interface IPatientService
    {
        void CreatePatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int? id);
        User GetPatientById(int? id);
        IReadOnlyCollection<Patient> GetAllPatients();
    }
}
