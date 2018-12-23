using System.Web.Mvc;

namespace EC.Web.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
    }
}