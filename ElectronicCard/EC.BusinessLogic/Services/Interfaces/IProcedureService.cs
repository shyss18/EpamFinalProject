using System.Collections.Generic;
using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Interfaces
{
    public interface IProcedureService
    {
        void CreateProcedure(Procedure procedure);
        void UpdateProcedure(Procedure procedure);
        Procedure GetById(int? id);
        void DeleteProcedure(int? id);
        IReadOnlyCollection<Procedure> GetAll();
    }
}
