using System.Collections.Generic;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Implementation
{
    public class PhoneRepository : IPhoneRepository
    {
        public PhoneRepository()
        {

        }

        public void Create(Phone item)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Phone item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Phone GetById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyCollection<Phone> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
