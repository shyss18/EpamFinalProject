using System.Collections.Generic;
using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Implementation
{
    public class PreparationService : IPreparationService
    {
        private readonly IPreparationRepository _preparationRepository;

        public PreparationService(IPreparationRepository preparationRepository)
        {
            _preparationRepository = preparationRepository;
        }

        public void CreatePreparation(Preparation preparation)
        {
            if (preparation == null)
            {
                return;
            }

            _preparationRepository.Create(preparation);
        }

        public void UpdatePreparation(Preparation preparation)
        {
            if (preparation == null)
            {
                return;
            }

            _preparationRepository.Update(preparation);
        }

        public void DeletePreparation(int? id)
        {
            if (id == null || id <= 0)
            {
                return;
            }

            _preparationRepository.Delete(id);
        }

        public Preparation GetById(int? id)
        {
            return id == null || id <= 0 ? null : _preparationRepository.GetById(id);
        }

        public IReadOnlyCollection<Preparation> GetAll()
        {
            return _preparationRepository.GetAll();
        }
    }
}
