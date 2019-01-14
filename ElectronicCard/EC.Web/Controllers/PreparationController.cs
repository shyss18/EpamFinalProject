using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;
using System.Web.Mvc;

namespace EC.Web.Controllers
{
    public class PreparationController : Controller
    {
        private readonly IPreparationService _preparationService;

        public PreparationController(IPreparationService preparationService)
        {
            _preparationService = preparationService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult CreatePreparation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePreparation(Preparation preparation)
        {
            if (ModelState.IsValid)
            {
                _preparationService.CreatePreparation(preparation);

                return RedirectToAction("GetAllPreparations");
            }

            return View(preparation);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult PreparationDetails(int? id)
        {
            var preparation = _preparationService.GetById(id);

            if (preparation == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(preparation);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult UpdatePreparation(int? id)
        {
            var preparation = _preparationService.GetById(id);

            if (preparation == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(preparation);
        }

        [HttpPost]
        public ActionResult UpdatePreparation(Preparation preparation)
        {
            if (ModelState.IsValid)
            {
                _preparationService.UpdatePreparation(preparation);

                return RedirectToAction("PreparationDetails", preparation.Id);
            }

            return View(preparation);
        }

        [HttpPost]
        public ActionResult DeletePreparation(int? id)
        {
            _preparationService.DeletePreparation(id);

            return RedirectToAction("GetAllPreparations");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult GetAllPreparations()
        {
            var preparation = _preparationService.GetAll();

            return View(preparation);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult GetPreparationForSelect()
        {
            var preparations = _preparationService.GetAll();

            return PartialView(preparations);
        }

        [HttpGet]
        public JsonResult CheckTimeUse(string TimeUse)
        {
            if (int.TryParse(TimeUse, out var check))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json("Введите число", JsonRequestBehavior.AllowGet);
        }
    }
}