using System.Web.Mvc;
using EC.BusinessLogic.Services.Interfaces;

namespace EC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdvertisingService _advertisingService;

        public HomeController(IAdvertisingService advertisingService)
        {
            _advertisingService = advertisingService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public FileContentResult GetImage()
        {
            var photo = _advertisingService.GetPromotionImage();

            if (photo != null)
            {
                return File(photo.Image, photo.TypeImage);
            }

            return null;
        }
    }
}