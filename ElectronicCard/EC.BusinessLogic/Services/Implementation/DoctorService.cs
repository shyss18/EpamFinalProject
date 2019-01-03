using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using System.Collections.Generic;

namespace EC.BusinessLogic.Services.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IUserRepository _userRepository;

        public DoctorService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateDoctor(Doctor doctor)
        {
            _userRepository.Create(doctor);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            _userRepository.Update(doctor);
        }

        public void DeleteDoctor(int? id)
        {
            _userRepository.Delete(id);
        }

        public User GetDoctorById(int? id)
        {
            return id == null ? null : _userRepository.GetById(id);
        }

        public IReadOnlyCollection<Doctor> GetAllDoctors()
        {
            return _userRepository.GetAllDoctors();
        }
    }
}
