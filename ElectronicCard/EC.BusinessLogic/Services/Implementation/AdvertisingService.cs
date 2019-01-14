using EC.BusinessLogic.MyService;
using EC.BusinessLogic.Services.Interfaces;

namespace EC.BusinessLogic.Services.Implementation
{
    public class AdvertisingService : IAdvertisingService
    {
        private readonly PromotionServiceClient _promotionService;

        public AdvertisingService()
        {
            _promotionService = new PromotionServiceClient();
        }

        public Promotion GetPromotionImage()
        {
            var image = _promotionService.GetPromotionImage();

            return image;
        }
    }
}
