using EC.Entities.Entities;
using System.Collections.Generic;

namespace EC.BusinessLogic.Services.Interfaces
{
    public interface IPhoneService
    {
        void CreatePhone(Phone phone);
        void UpdatePhone(Phone phone);
        void DeletePhone(int? id);
        IReadOnlyCollection<Phone> GetUserContacts(string login);
    }
}
