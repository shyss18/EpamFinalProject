using System.Web.Mvc;

namespace EC.Web.Controllers
{
    public class AuthController : Controller
    {
        public AuthController()
        {
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUpPatient()
        {
            return View();
        }
    }
}