using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;
using EC.Web.Models;
using System.Web.Mvc;

namespace EC.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsDoctor)
                {
                    var doctor = new Doctor
                    {
                        Login = model.Login,
                        Email = model.Email,
                        Password = model.Password,
                        FirstName = model.FirstName,
                        MiddleName = model.MiddleName,
                        LastName = model.LastName,
                        Position = model.Position,
                        PhoneNumbers = model.Phones,
                        Roles = model.Roles
                    };

                    _userService.CreateUser(doctor);
                }
                else
                {
                    var patient = new Patient()
                    {
                        Login = model.Login,
                        Email = model.Email,
                        Password = model.Password,
                        FirstName = model.FirstName,
                        MiddleName = model.MiddleName,
                        LastName = model.LastName,
                        PlaceWork = model.Position,
                        DateBirth = model.DateBirth,
                        PhoneNumbers = model.Phones,
                        Roles = model.Roles
                    };

                    _userService.CreateUser(patient);
                }

                return RedirectToAction("AllUsers");
            }

            return View(model);
        }
        
        [HttpGet]
        public ActionResult GetListDoctors()
        {
            var doctors = _userService.GetAllDoctors();

            return PartialView(doctors);
        }

        [HttpGet]
        public ActionResult GetListPatient()
        {
            var patients = _userService.GetAllPatients();

            return PartialView(patients);
        }
    }
}