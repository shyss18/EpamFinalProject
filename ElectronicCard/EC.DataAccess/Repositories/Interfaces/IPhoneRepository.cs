using System.Collections.Generic;
using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Interfaces
{
    public interface IPhoneRepository
    {
        IEnumerable<Phone> GetPhones();
    }
}
