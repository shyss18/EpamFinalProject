using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using System.Collections.Generic;

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
            if (diagnosis == null)
            {
                return;
            }

            _repository.Create(diagnosis);
        }

        public void UpdateDiagnosis(Diagnosis diagnosis)
        {
            if (diagnosis == null)
            {
                return;
            }

            _repository.Update(diagnosis);
        }

        public void DeleteDiagnosis(int? id)
        {
            if (id == null || id <= 0)
            {
                return;
            }

            _repository.Delete(id);
        }

        public Diagnosis GetById(int? id)
        {
            return id == null || id <= 0 ? null : _repository.GetById(id);
        }

        public IReadOnlyCollection<Diagnosis> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
