using System.Collections.Generic;
using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Interfaces
{
    public interface ISickLeaveService
    {
        void CreateSickLeave(SickLeave sickLeave);
        void UpdateSickLeave(SickLeave sickLeave);
        void DeleteSickLeave(int? id);
        SickLeave GetById(int? id);
        IReadOnlyCollection<SickLeave> GetAll();
    }
}
