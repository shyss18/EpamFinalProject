using System.Web.Mvc;
using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;

namespace EC.Web.Controllers
{
    public class DiagnosisController : Controller
    {
        private readonly IDiagnosisService _diagnosisService;

        public DiagnosisController(IDiagnosisService service)
        {
            _diagnosisService = service;
        }

        [HttpGet]
        public ActionResult CreateDiagnosis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDiagnosis(Diagnosis diagnosis)
        {
            if (ModelState.IsValid)
            {
                _diagnosisService.CreateDiagnosis(diagnosis);

                return RedirectToAction("GetAllDiagnoses");
            }

            return View(diagnosis);
        }

        [HttpGet]
        public ActionResult DiagnosisDetails(int? id)
        {
            var diagnosis = _diagnosisService.GetById(id);

            if (diagnosis == null)
            {
                return HttpNotFound();
            }

            return View(diagnosis);
        }

        [HttpGet]
        public ActionResult UpdateDiagnosis(int? id)
        {
            var diagnosis = _diagnosisService.GetById(id);

            if (diagnosis == null)
            {
                return View("NotFound");
            }

            return View(diagnosis);
        }

        [HttpPost]
        public ActionResult UpdateDiagnosis(Diagnosis diagnosis)
        {
            if (ModelState.IsValid)
            {
                _diagnosisService.UpdateDiagnosis(diagnosis);

                return RedirectToAction("GetAllDiagnoses");
            }

            return View(diagnosis);
        }

        [HttpPost]
        public ActionResult DeleteDiagnosis(int? id)
        {
            _diagnosisService.DeleteDiagnosis(id);

            return RedirectToAction("GetAllDiagnoses");
        }

        [HttpGet]
        public ActionResult GetAllDiagnoses()
        {
            var diagnoses = _diagnosisService.GetAll();

            return View(diagnoses);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult GetDiagnosisForSelect()
        {
            var diagnoses = _diagnosisService.GetAll();

            return PartialView(diagnoses);
        }
    }
}