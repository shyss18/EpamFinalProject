using System.Collections.Generic;
using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly IUserRepository _userRepository;

        public PatientService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreatePatient(Patient patient)
        {
            _userRepository.Create(patient);
        }

        public void Delete(int? id)
        {
            _userRepository.Delete(id);
        }

        public User GetPatientById(int? id)
        {
            return id == null ? null : _userRepository.GetById(id);
        }

        public void UpdatePatient(Patient patient)
        {
            _userRepository.Update(patient);
        }

        public void DeletePatient(int? id)
        {
            _userRepository.Delete(id);
        }

        public IReadOnlyCollection<Patient> GetAllPatients()
        {
            return _userRepository.GetAllPatients();
        }
    }
}
