using EC.PromotionService.Models;
using System.ServiceModel;

namespace EC.PromotionService
{
    [ServiceContract]
    public interface IPromotionService
    {
        [OperationContract]
        Promotion GetPromotionImage();
    }
}
