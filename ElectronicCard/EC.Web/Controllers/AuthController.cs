using System.Web.Mvc;
using EC.Web.Models;

namespace EC.Web.Controllers
{
    public class AuthController : Controller
    {
        private static bool _isDoctor;

        public AuthController()
        {

        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            ViewBag.IsDoctor = _isDoctor;

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(RegistrationModel user)
        {
            ViewBag.IsDoctor = _isDoctor;

            if (ModelState.IsValid)
            {

            }

            return View(user);
        }

        [HttpPost]
        public ActionResult CheckForDoctor(string code)
        {
            const string verificationCode = "123456";

            if (verificationCode.Equals(code))
            {
                _isDoctor = true;

                return RedirectToAction("SignUp");
            }
            else
            {
                _isDoctor = false;

                return RedirectToAction("SignUp");
            }
        }
    }
}