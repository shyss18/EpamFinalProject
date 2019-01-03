using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using System.Collections.Generic;

namespace EC.BusinessLogic.Services.Implementation
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneService(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public void CreatePhone(Phone phone)
        {
            _phoneRepository.Create(phone);
        }

        public void UpdatePhone(Phone phone)
        {
            _phoneRepository.Update(phone);
        }

        public void DeletePhone(int? id)
        {
            _phoneRepository.Delete(id);
        }

        public Phone GetById(int? id)
        {
            return id == null ? null : _phoneRepository.GetById(id);
        }

        public IReadOnlyCollection<Phone> GetUserPhones(int? userId)
        {
            return userId == null ? null : _phoneRepository.GetUserPhones(userId);
        }
    }
}
