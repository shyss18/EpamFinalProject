using System.Web.Mvc;
using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;
using EC.Web.Models;

namespace EC.Web.Controllers
{
    public class SickLeaveController : Controller
    {
        private readonly ISickLeaveService _sickLeaveService;
        private readonly IDiagnosisService _diagnosisService;

        public SickLeaveController(ISickLeaveService sickLeaveService, IDiagnosisService diagnosisService)
        {
            _sickLeaveService = sickLeaveService;
            _diagnosisService = diagnosisService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Editor, Doctor")]
        public ActionResult CreateSickLeave()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSickLeave(CreateSickLeaveModel sickLeave)
        {
            if (ModelState.IsValid)
            {
                var diagnosis = _diagnosisService.GetById(sickLeave.DiagnosisId);

                var sick = new SickLeave
                {
                    IsGive = sickLeave.IsGive,
                    Number = sickLeave.Number,
                    PeriodAction = sickLeave.PeriodAction,
                    DiagnosisId = diagnosis.Id,
                    Diagnosis = diagnosis
                };

                _sickLeaveService.CreateSickLeave(sick);

                return RedirectToAction("GetAllSickLeaves");
            }

            return View(sickLeave);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Editor, Doctor")]
        public ActionResult SickLeaveDetails(int? id)
        {
            var sickLeave = _sickLeaveService.GetById(id);

            if (sickLeave == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(sickLeave);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Editor, Doctor")]
        public ActionResult UpdateSickLeave(int? id)
        {
            var sickLeave = _sickLeaveService.GetById(id);

            if (sickLeave != null)
            {
                var edit = new EditSickLeaveModel
                {
                    Id = sickLeave.Id,
                    IsGive = sickLeave.IsGive,
                    Number = sickLeave.Number,
                    PeriodAction = sickLeave.PeriodAction,
                    DiagnosisId = sickLeave.DiagnosisId
                };

                return View(edit);
            }

            return RedirectToAction("NotFound", "Error");
        }

        [HttpPost]
        public ActionResult UpdateSickLeave(EditSickLeaveModel edit)
        {
            if (ModelState.IsValid)
            {
                var sickLeave = _sickLeaveService.GetById(edit.Id);
                var diagnosis = _diagnosisService.GetById(edit.DiagnosisId);

                sickLeave.IsGive = edit.IsGive;
                sickLeave.Number = edit.Number;
                sickLeave.PeriodAction = edit.PeriodAction;
                sickLeave.DiagnosisId = edit.DiagnosisId;
                sickLeave.Diagnosis = diagnosis;

                _sickLeaveService.UpdateSickLeave(sickLeave);

                return RedirectToAction("GetAllSickLeaves");
            }

            return View(edit);
        }

        [HttpPost]
        public ActionResult DeleteSickLeave(int? id)
        {
            _sickLeaveService.DeleteSickLeave(id);

            return RedirectToAction("GetAllSickLeaves");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Editor, Doctor")]
        public ActionResult GetAllSickLeaves()
        {
            var sickLeaves = _sickLeaveService.GetAll();

            return View(sickLeaves);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult GetSickLeaveForSelect()
        {
            var sickLeave = _sickLeaveService.GetAll();

            return PartialView(sickLeave);
        }
    }
}