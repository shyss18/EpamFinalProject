using System.Collections.Generic;
using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Interfaces
{
    public interface IPreparationService
    {
        void CreatePreparation(Preparation preparation);
        void UpdatePreparation(Preparation preparation);
        void DeletePreparation(int? id);
        Preparation GetById(int? id);
        IReadOnlyCollection<Preparation> GetAll();
    }
}
