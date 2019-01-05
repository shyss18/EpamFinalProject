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
        public ActionResult PreparationDetails(int? id)
        {
            var preparation = _preparationService.GetById(id);

            if (preparation == null)
            {
                return HttpNotFound();
            }

            return View(preparation);
        }

        [HttpGet]
        public ActionResult UpdatePreparation(int? id)
        {
            var preparation = _preparationService.GetById(id);

            if (preparation == null)
            {
                return View("NotFound");
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
        public ActionResult GetAllPreparations()
        {
            var preparation = _preparationService.GetAll();

            return View(preparation);
        }
    }
}