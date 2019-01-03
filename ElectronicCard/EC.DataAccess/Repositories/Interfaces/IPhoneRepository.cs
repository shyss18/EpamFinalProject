using System.Collections.Generic;
using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Interfaces
{
    public interface IPhoneRepository : IRepository<Phone>
    {
        IReadOnlyCollection<Phone> GetUserPhones(int? userId);
    }
}
