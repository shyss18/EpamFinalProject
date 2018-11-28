using System.Collections.Generic;
using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Implementation
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneService(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public IEnumerable<Phone> GetPhones()
        {
            return _phoneRepository.GetPhones();
        }
    }
}
