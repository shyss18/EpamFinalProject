using EC.BusinessLogic.MyService;
using EC.BusinessLogic.Services.Interfaces;
using System.ServiceModel;
using static System.Int32;

namespace EC.BusinessLogic.Services.Implementation
{
    public class AdvertisingService : IAdvertisingService
    {
        private MyService.IPromotionService _promotionService;

        public AdvertisingService()
        {
            CreateChannel();
        }

        public IPromotionService CreateChannel()
        {
            var binding = new BasicHttpBinding
            {
                MaxReceivedMessageSize = MaxValue
            };
            
            var channelFactory = new ChannelFactory<IPromotionService>(binding, "http://localhost/EC.PromotionService/PromotionService.svc");
            
            _promotionService = channelFactory.CreateChannel();

            return _promotionService;
        }

        public Promotion GetPromotionImage()
        {
            var image = _promotionService.GetPromotionImage();

            return image;
        }
    }
}
