using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;
using EC.Web.Models;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace EC.Web.Controllers
{
    public class UserController : Controller
    {
        private static bool _isDoctor;

        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(CreateUserModel model)
        {
            //if (ModelState.IsValid)
            //{
                User user;

                if (model.IsDoctor)
                {
                    user = new Doctor
                    {
                        Login = model.Login,
                        Email = model.Email,
                        Password = model.Password,
                        FirstName = model.FirstName,
                        MiddleName = model.MiddleName,
                        LastName = model.LastName,
                        Position = model.Position,
                        IsDoctor = model.IsDoctor,
                        Patients = _userService.GetAllPatients().Where(u => model.Patients.Contains(u.Id)).ToList(),
                        PhoneNumbers = (IReadOnlyCollection<Phone>)model.Phones,
                        Roles = _roleService.GetAll().Where(role => model.Roles.Contains(role.Id)).ToList()
                    };
                }
                else
                {
                    user = new Patient()
                    {
                        Login = model.Login,
                        Email = model.Email,
                        Password = model.Password,
                        FirstName = model.FirstName,
                        MiddleName = model.MiddleName,
                        LastName = model.LastName,
                        PlaceWork = model.Position,
                        DateBirth = model.DateBirth,
                        IsDoctor = model.IsDoctor,
                        Doctors = _userService.GetAllDoctors().Where(u => model.Doctors.Contains(u.Id)).ToList(),
                        PhoneNumbers = (IReadOnlyCollection<Phone>)model.Phones,
                        Roles = _roleService.GetAll().Where(role => model.Roles.Contains(role.Id)).ToList()
                    };
                }

                if (model.Photo != null)
                {
                    user.Photo = new Photo
                    {
                        Image = new byte[model.Photo.ContentLength],
                        ImageType = model.Photo.ContentType
                    };

                    model.Photo.InputStream.Read(user.Photo.Image, 0, model.Photo.ContentLength);
                }

                _userService.CreateUser(user);

                return RedirectToAction("AllUsers");
            //}

            //return View(model);
        }

        [HttpGet]
        public ActionResult UpdateUser(string login)
        {
            var user = _userService.GetUserByLogin(login);

            if (user != null)
            {
                ViewBag.IsDoctor = user.IsDoctor;

                return View(user);
            }

            return View("NotFound");
        }


        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult GetListDoctors()
        {
            var doctors = _userService.GetAllDoctors();

            return PartialView(doctors);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult GetListPatient()
        {
            var patients = _userService.GetAllPatients();

            return PartialView(patients);
        }
    }
}