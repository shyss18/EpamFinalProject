using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;
using System.Web.Mvc;

namespace EC.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public ActionResult CreatePatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _patientService.CreatePatient(patient);
            }

            return View(patient);
        }

        [HttpGet]
        public ActionResult UpdatePatient(int? id)
        {
            var patient = _patientService.GetPatientById(id);

            return patient == null ? View("NotFound") : View(patient);
        }

        [HttpPost]
        public ActionResult UpdatePatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _patientService.UpdatePatient(patient);
            }

            return View(patient);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var patient = _patientService.GetPatientById(id);

            return patient == null ? View("NotFound") : View(patient);
        }

        [HttpPost]
        public ActionResult DeletePatient(int? id)
        {
            _patientService.DeletePatient(id);

            return View();
        }

        [HttpGet]
        public ActionResult GetAllPatients()
        {
            var patients = _patientService.GetAllPatients();

            return View(patients);
        }
    }
}