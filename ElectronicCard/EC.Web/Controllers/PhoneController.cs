using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;
using System.Web.Mvc;

namespace EC.Web.Controllers
{
    public class PhoneController : Controller
    {
        private readonly IPhoneService _phoneService;

        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [HttpGet]
        public ActionResult AddPhone()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPhone(Phone phone)
        {
            if (ModelState.IsValid)
            {
                _phoneService.CreatePhone(phone);
            }

            return View();
        }

        [HttpGet]
        public ActionResult UpdatePhone(int? id)
        {
            var phone = _phoneService.GetById(id);

            return View(phone);
        }

        [HttpPost]
        public ActionResult UpdatePhone(Phone phone)
        {
            if (ModelState.IsValid)
            {
                _phoneService.UpdatePhone(phone);
            }

            return View(phone);
        }

        [HttpPost]
        public ActionResult DeletePhone(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            _phoneService.DeletePhone(id);

            return View();
        }

        [HttpGet]
        public ActionResult UserPhones(int? userId)
        {
            var userPhones = _phoneService.GetUserPhones(userId);

            if (userPhones == null)
            {
                return View("NotFound");
            }

            return View(userPhones);
        }
    }
}