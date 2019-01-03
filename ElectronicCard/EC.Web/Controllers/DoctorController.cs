using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;
using System.Web.Mvc;

namespace EC.Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public ActionResult CreateDoctor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDoctor(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _doctorService.CreateDoctor(doctor);
            }

            return View(doctor);
        }

        [HttpGet]
        public ActionResult UpdateDoctor(int? id)
        {
            var doctor = _doctorService.GetDoctorById(id);

            return doctor == null ? View("NotFound") : View(doctor);
        }

        [HttpPost]
        public ActionResult UpdateDoctor(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _doctorService.UpdateDoctor(doctor);
            }

            return View(doctor);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var doctor = _doctorService.GetDoctorById(id);

            return doctor == null ? View("NotFound") : View(doctor);
        }

        [HttpPost]
        public ActionResult DeleteDoctor(int? id)
        {
            _doctorService.DeleteDoctor(id);

            return View();
        }

        [HttpGet]
        public ActionResult GetAllDoctors()
        {
            var doctors = _doctorService.GetAllDoctors();

            return View(doctors);
        }
    }
}