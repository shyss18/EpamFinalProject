using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using System.Collections.Generic;

namespace EC.BusinessLogic.Services.Implementation
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;
        private readonly IUserRepository _userRepository;

        public PhoneService(IPhoneRepository phoneRepository, IUserRepository userRepository)
        {
            _phoneRepository = phoneRepository;
            _userRepository = userRepository;
        }

        public void CreatePhone(Phone phone)
        {
            if (phone == null)
            {
                return;
            }

            _phoneRepository.Create(phone);
        }

        public void UpdatePhone(Phone phone)
        {
            if (phone == null)
            {
                return;
            }

            _phoneRepository.Update(phone);
        }

        public void DeletePhone(int? id)
        {
            if (id == null || id <= 0)
            {
                return;
            }

            _phoneRepository.Delete(id);
        }

        public Phone GetPhoneByNumber(string number)
        {
            return number == null  ? null : _phoneRepository.GetPhoneByNumber(number);
        }

        public IReadOnlyCollection<Phone> GetUserContacts(string login)
        {
            if (login == null)
            {
                return null;
            }

            var user = _userRepository.GetUserByLogin(login);

            var phones = _phoneRepository.GetUserPhones(user.Id);

            return phones;
        }
    }
}
