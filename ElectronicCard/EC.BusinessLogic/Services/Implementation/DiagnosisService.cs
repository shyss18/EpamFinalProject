using System.Collections.Generic;
using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Implementation
{
    public class DiagnosisService : IDiagnosisService
    {
        private readonly IDiagnosisRepository _repository;

        public DiagnosisService(IDiagnosisRepository repository)
        {
            _repository = repository;
        }

        public void CreateDiagnosis(Diagnosis diagnosis)
        {
            _repository.Create(diagnosis);
        }

        public void UpdateDiagnosis(Diagnosis diagnosis)
        {
            _repository.Update(diagnosis);
        }

        public void DeleteDiagnosis(int? id)
        {
            _repository.Delete(id);
        }

        public Diagnosis GetById(int? id)
        {
            return id == null ? null : _repository.GetById(id);
        }

        public IReadOnlyCollection<Diagnosis> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
