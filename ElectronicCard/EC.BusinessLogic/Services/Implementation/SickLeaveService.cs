using System.Collections.Generic;
using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Implementation
{
    public class SickLeaveService : ISickLeaveService
    {
        private readonly ISickLeaveRepository _repository;

        public SickLeaveService(ISickLeaveRepository repository)
        {
            _repository = repository;
        }

        public void CreateSickLeave(SickLeave sickLeave)
        {
            _repository.Create(sickLeave);
        }

        public void UpdateSickLeave(SickLeave sickLeave)
        {
            _repository.Update(sickLeave);
        }

        public void DeleteSickLeave(int? id)
        {
            _repository.Delete(id);
        }

        public SickLeave GetById(int? id)
        {
            return id == null ? null : _repository.GetById(id);
        }

        public IReadOnlyCollection<SickLeave> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
