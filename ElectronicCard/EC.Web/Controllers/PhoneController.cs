using System.Web.Mvc;
using EC.BusinessLogic.Services.Interfaces;

namespace EC.Web.Controllers
{
    public class PhoneController : Controller
    {
        private readonly IPhoneService _phoneService;

        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        public ActionResult Index()
        {
            return View(_phoneService.GetPhones());
        }
    }
}