using System.Web.Mvc;

namespace EC.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult NotFound()
        {
            return View();
        }

        public ViewResult Forbidden()
        {
            return View();
        }

        public ViewResult ServerError()
        {
            return View();
        }
    }
}