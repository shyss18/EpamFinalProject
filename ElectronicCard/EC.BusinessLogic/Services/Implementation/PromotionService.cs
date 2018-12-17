using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;

namespace EC.BusinessLogic.Services.Implementation
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _repository;

        public PromotionService(IPromotionRepository repository)
        {
            _repository = repository;
        }


        public string TestConnection()
        {
            return _repository.TestConnection();
        }
    }
}
