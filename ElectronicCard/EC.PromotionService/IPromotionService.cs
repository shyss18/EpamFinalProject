using System.Collections.Generic;
using System.ServiceModel;
using EC.Entities.Entities;

namespace EC.PromotionService
{
    [ServiceContract]
    public interface IPromotionService
    {
        [OperationContract]
        string TestConnection();

        [OperationContract]
        void CreatePromotion(Promotion item);

        [OperationContract]
        Promotion GetByIdPromotion(int? id);

        [OperationContract]
        IReadOnlyCollection<Promotion> GetAllPromotions();

        [OperationContract]
        void DeletePromotion(int? id);

        [OperationContract]
        void UpdatePromotion(int? id);
    }
}
