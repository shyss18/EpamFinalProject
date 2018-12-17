using System.Web.Mvc;
using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;

namespace EC.Web.Controllers
{
    public class SickLeaveController : Controller
    {
        private readonly ISickLeaveService _sickLeaveService;

        public SickLeaveController(ISickLeaveService sickLeaveService)
        {
            _sickLeaveService = sickLeaveService;
        }

        [HttpGet]
        public ActionResult CreateSickLeave()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSickLeave(SickLeave sickLeave)
        {
            if (ModelState.IsValid)
            {
                _sickLeaveService.CreateSickLeave(sickLeave);
            }

            return View(sickLeave);
        }

        [HttpGet]
        public ActionResult SickLeaveDetails(int? id)
        {
            var sickLeave = _sickLeaveService.GetById(id);

            if (sickLeave == null)
            {
                return HttpNotFound();
            }

            return View(sickLeave);
        }

        [HttpGet]
        public ActionResult UpdateSickLeave(int? id)
        {
            var sickLeave = _sickLeaveService.GetById(id);

            if (sickLeave == null)
            {
                return View("NotFound");
            }

            return View(sickLeave);
        }

        [HttpPost]
        public ActionResult UpdateSickLeave(SickLeave sickLeave)
        {
            if (ModelState.IsValid)
            {
                _sickLeaveService.UpdateSickLeave(sickLeave);
            }

            return View(sickLeave);
        }

        [HttpPost]
        public ActionResult DeleteSickLeave(int? id)
        {
            _sickLeaveService.DeleteSickLeave(id);

            return View();
        }

        [HttpGet]
        public ActionResult GetAllSickLeaves()
        {
            var diagnoses = _sickLeaveService.GetAll();

            return View(diagnoses);
        }
    }
}