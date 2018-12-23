using System.Collections.Generic;
using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Interfaces
{
    public interface IDiagnosisService
    {
        void CreateDiagnosis(Diagnosis diagnosis);
        void UpdateDiagnosis(Diagnosis diagnosis);
        void DeleteDiagnosis(int? id);
        Diagnosis GetById(int? id);
        IReadOnlyCollection<Diagnosis> GetAll();
    }
}
