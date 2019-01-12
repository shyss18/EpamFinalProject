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
            if (sickLeave == null)
            {
                return;
            }

            _repository.Create(sickLeave);
        }

        public void UpdateSickLeave(SickLeave sickLeave)
        {
            if (sickLeave == null)
            {
                return;
            }

            _repository.Update(sickLeave);
        }

        public void DeleteSickLeave(int? id)
        {
            if (id == null || id <= 0)
            {
                return;
            }

            _repository.Delete(id);
        }

        public SickLeave GetById(int? id)
        {
            return id == null || id <= 0 ? null : _repository.GetById(id);
        }

        public IReadOnlyCollection<SickLeave> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
