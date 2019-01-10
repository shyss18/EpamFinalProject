using System;
using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;
using EC.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EC.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(CreateUserModel model)
        {
            if (model.Photo != null && !model.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("", "Выберете фотографию для загрузки");
            }

            if (ModelState.IsValid)
            {
                User user;

                if (model.IsDoctor)
                {
                    user = new User
                    {
                        Login = model.Login,
                        Password = model.Password,
                        Email = model.Email,
                        IsDoctor = model.IsDoctor,
                        PhoneNumbers = new List<Phone>
                        {
                            new Phone
                            {
                                PhoneNumber = model.Phone
                            }
                        },
                        Doctor = new Doctor
                        {
                            FirstName = model.FirstName,
                            MiddleName = model.MiddleName,
                            LastName = model.LastName,
                            Position = model.Position,
                        }
                    };

                    if (model.Patients != null)
                    {
                        user.Doctor.Patients =
                            _userService.GetAllPatients().Where(p => model.Patients.Contains(p.UserId)).ToList();
                    }
                }
                else
                {
                    user = new User
                    {
                        Login = model.Login,
                        Password = model.Password,
                        Email = model.Email,
                        IsDoctor = model.IsDoctor,
                        PhoneNumbers = new List<Phone>
                        {
                            new Phone
                            {
                                PhoneNumber = model.Phone
                            }
                        },
                        Patient = new Patient
                        {
                            FirstName = model.FirstName,
                            MiddleName = model.MiddleName,
                            LastName = model.LastName,
                            DateBirth = model.DateBirth,
                            PlaceWork = model.PlaceWork
                        }
                    };

                    if (model.Doctors != null)
                    {
                        user.Patient.Doctors =
                            _userService.GetAllDoctors().Where(d => model.Doctors.Contains(d.UserId)).ToList();
                    }
                }

                user.Roles = _roleService.GetAll().Where(r => model.Roles.Contains(r.Id)).ToList();

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

                return View("GetAllUsers", _userService.GetAllUsers());
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Editor, Doctor")]
        public ActionResult UserDetails(int? id)
        {
            var user = _userService.GetUserById(id);

            if (user != null)
            {
                return View(user);
            }

            return View("NotFound");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditUser(int? id)
        {
            var user = _userService.GetUserById(id);

            if (user != null)
            {
                var edit = new EditUserModel
                {
                    Id = user.Id,
                    IsDoctor = user.IsDoctor,
                    Roles = user.Roles.Select(r => r.Id).ToArray()
                };

                if (user.IsDoctor)
                {
                    edit.FirstName = user.Doctor.FirstName;
                    edit.MiddleName = user.Doctor.MiddleName;
                    edit.LastName = user.Doctor.LastName;
                    edit.Position = user.Doctor.Position;

                    if (user.Doctor.Patients != null)
                    {
                        edit.Patients = user.Doctor.Patients.Select(p => p.Id).ToArray();
                    }
                }
                else
                {
                    edit.FirstName = user.Patient.FirstName;
                    edit.MiddleName = user.Patient.MiddleName;
                    edit.LastName = user.Patient.LastName;
                    edit.PlaceWork = user.Patient.PlaceWork;
                    edit.PlaceWork = user.Patient.PlaceWork;

                    if (user.Patient.Doctors != null)
                    {
                        edit.Doctors = user.Patient.Doctors.Select(p => p.Id).ToArray();
                    }
                }

                return View(edit);
            };

            return View("NotFound");
        }

        [HttpPost]
        public ActionResult EditUser(EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetUserById(model.Id);

                if (user.IsDoctor)
                {
                    user.Doctor.FirstName = model.FirstName;
                    user.Doctor.MiddleName = model.MiddleName;
                    user.Doctor.LastName = model.LastName;
                    user.Doctor.Position = model.Position;

                    if (model.Patients == null)
                    {
                        user.Doctor.Patients = new List<Patient>();
                    }

                    if (model.Patients != null)
                    {
                        user.Doctor.Patients = _userService.GetAllPatients().Where(p => model.Patients.Contains(p.UserId)).ToList();
                    }
                }
                else
                {
                    user.Patient.FirstName = model.FirstName;
                    user.Patient.MiddleName = model.MiddleName;
                    user.Patient.LastName = model.LastName;
                    user.Patient.PlaceWork = model.PlaceWork;
                    user.Patient.DateBirth = model.DateBirth;

                    if (model.Doctors == null)
                    {
                        user.Patient.Doctors = new List<Doctor>();
                    }

                    if (model.Doctors != null)
                    {
                        user.Patient.Doctors = _userService.GetAllDoctors().Where(d => model.Doctors.Contains(d.Id))
                            .ToList();
                    }
                }

                user.Roles = _roleService.GetAll().Where(r => model.Roles.Contains(r.Id)).ToList();

                _userService.UpdateUser(user);

                return RedirectToAction("UserDetails", new { id = user.Id });
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();

            return View(users);
        }

        [HttpPost]
        public ActionResult DeleteUser(int? id)
        {
            if (_userService.DeleteUser(id))
            {
                return RedirectToAction("GetAllUsers");
            }

            return View("WarningDelete");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Editor, Doctor")]
        public ActionResult GetPatients(string login)
        {
            var doctor = _userService.GetUserByLogin(login);

            if (doctor != null)
            {
                return View("Patients", _userService.GetUserPatients(doctor.Id));
            }

            return View("NotFound");
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Patch)]
        public ActionResult GetDoctorForSelect(string login)
        {
            var doctor = _userService.GetUserByLogin(login);

            return doctor == null ? null : PartialView("GetDoctorForSelect", doctor.Doctor);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Patch)]
        public ActionResult GetDoctorPatients(string login)
        {
            var doctor = _userService.GetUserByLogin(login);

            if (doctor != null)
            {
                var users = _userService.GetUserPatients(doctor.Id);

                return PartialView("GetDoctorPatients", users);
            }

            return PartialView("GetListPatient", _userService.GetAllPatients());
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

        [HttpGet]
        public JsonResult CheckDate(string DateBirth)
        {
            if (!DateTime.TryParse(DateBirth, out var parsedDate))
            {
                return Json("Пожалуйста, введите дату в формате (мм.дд.гггг)",
                    JsonRequestBehavior.AllowGet);
            }

            if (DateTime.Now < parsedDate)
            {
                return Json("Введите дату не относящуюся к будущему",
                    JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}