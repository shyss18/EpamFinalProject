using EC.BusinessLogic.MyService;
using EC.BusinessLogic.Services.Interfaces;
using System.ServiceModel;

namespace EC.BusinessLogic.Services.Implementation
{
    public class AdvertisingService : IAdvertisingService
    {
        private readonly IPromotionService _promotionService;

        public AdvertisingService()
        {
            var channelFactory = new ChannelFactory<IPromotionService>(new BasicHttpBinding(), "http://localhost/EC.PromotionService/PromotionService.svc");

            _promotionService = channelFactory.CreateChannel();
        }
        
        public string TestConnection()
        {
            return _promotionService.TestConnection();
        }
    }
}
