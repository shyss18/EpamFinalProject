using System.Web.Mvc;
using EC.BusinessLogic.Services.Interfaces;

namespace EC.Web.Controllers
{
    public class AdvertisingController : Controller
    {
        private readonly IAdvertisingService _advertisingService;

        public AdvertisingController(IAdvertisingService advertisingService)
        {
            _advertisingService = advertisingService;
        }

        public string Test()
        {
            var result = _advertisingService.TestConnection();

            return result;
        }
    }
}