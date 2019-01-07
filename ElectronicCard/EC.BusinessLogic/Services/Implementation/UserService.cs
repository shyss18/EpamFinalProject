using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using System.Collections.Generic;

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
            _userRepository.Create(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(int? id)
        {
            _userRepository.Delete(id);
        }

        public User GetUserById(int? id)
        {
            return id == null ? null : _userRepository.GetById(id);
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
    }
}
