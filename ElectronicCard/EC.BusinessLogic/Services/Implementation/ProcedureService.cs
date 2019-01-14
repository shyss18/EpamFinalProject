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
            if (procedure == null)
            {
                return;
            }

            _procedureRepository.Create(procedure);
        }

        public void UpdateProcedure(Procedure procedure)
        {
            if (procedure == null)
            {
                return;
            }

            _procedureRepository.Update(procedure);
        }

        public void DeleteProcedure(int? id)
        {
            if (id == null || id <= 0)
            {
                return;
            }

            _procedureRepository.Delete(id);
        }

        public Procedure GetById(int? id)
        {
            return id == null || id <= 0 ? null : _procedureRepository.GetById(id);
        }

        public IReadOnlyCollection<Procedure> GetAll()
        {
            return _procedureRepository.GetAll();
        }
    }
}
