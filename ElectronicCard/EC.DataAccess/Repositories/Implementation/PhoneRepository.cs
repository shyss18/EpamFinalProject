using System.Collections.Generic;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Implementation
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly List<Phone> _phones;

        public PhoneRepository()
        {
            _phones = new List<Phone>
            {
                new Phone
                {
                    Id = 1,
                    PhoneNumber = "123456"
                },

                new Phone
                {
                    Id = 2,
                    PhoneNumber = "23456"
                }
            };
        }

        public IEnumerable<Phone> GetPhones()
        {
            return _phones;
        }
    }
}
