using System.Collections.Generic;
using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Implementation
{
    public class ProcedureService : IProcedureService
    {
        private readonly IProcedureRepository _procedureRepository;

        public ProcedureService(IProcedureRepository procedureRepository)
        {
            _procedureRepository = procedureRepository;
        }

        public void CreateProcedure(Procedure procedure)
        {
            _procedureRepository.Create(procedure);
        }

        public void UpdateProcedure(Procedure procedure)
        {
            _procedureRepository.Update(procedure);
        }

        public Procedure GetById(int? id)
        {
            return id == null ? null : _procedureRepository.GetById(id);
        }

        public void DeleteProcedure(int? id)
        {
            _procedureRepository.Delete(id);
        }

        public IReadOnlyCollection<Procedure> GetAll()
        {
            return _procedureRepository.GetAll();
        }
    }
}
