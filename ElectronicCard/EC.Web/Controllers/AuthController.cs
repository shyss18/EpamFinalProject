using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;
using EC.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace EC.Web.Controllers
{
    public class AuthController : Controller
    {
        private static bool _isDoctor;

        private readonly IAuthService _authService;
        private readonly IPhoneService _phoneService;

        public AuthController(IAuthService authService, IPhoneService phoneService)
        {
            _authService = authService;
            _phoneService = phoneService;
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInModel signIn)
        {
            if (ModelState.IsValid)
            {
                var response = _authService.SignIn(signIn.Login, signIn.Password);

                if (response)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(signIn);
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            ViewBag.IsDoctor = _isDoctor;

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(RegistrationModel registration)
        {
            ViewBag.IsDoctor = _isDoctor;

            if (ModelState.IsValid)
            {
                User user;

                if (registration.IsDoctor)
                {
                    user = new Doctor
                    {
                        Login = registration.Login,
                        Password = registration.Password,
                        Email = registration.Email,
                        FirstName = registration.FirstName,
                        MiddleName = registration.MiddleName,
                        LastName = registration.LastName,
                        Position = registration.Position,
                        IsDoctor = true,
                        PhoneNumbers = (IReadOnlyCollection<Phone>)registration.Phones
                    };
                }
                else
                {
                    user = new Patient
                    {
                        Login = registration.Login,
                        Password = registration.Password,
                        Email = registration.Email,
                        FirstName = registration.FirstName,
                        MiddleName = registration.MiddleName,
                        LastName = registration.LastName,
                        PlaceWork = registration.PlaceWork,
                        DateBirth = registration.DateBirth,
                        IsDoctor = false,
                        PhoneNumbers = (IReadOnlyCollection<Phone>)registration.Phones
                    };
                }

                if (registration.Photo != null)
                {
                    user.Photo = new Photo
                    {
                        Image = new byte[registration.Photo.ContentLength],
                        ImageType = registration.Photo.ContentType
                    };

                    registration.Photo.InputStream.Read(user.Photo.Image, 0, registration.Photo.ContentLength);
                }

                _authService.SignUp(user);

                return View("SuccessRegister");
            }

            return View(registration);
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            _authService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Account(string login)
        {
            var user = _authService.GetUserByLogin(login);

            if (user == null)
            {
                return View("NotFound");
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult EditAccount(string login)
        {
            var user = _authService.GetUserByLogin(login);

            if (user != null)
            {
                var model = new EditAccountModel
                {
                    Id = user.Id,
                    Login = user.Login,
                    Email = user.Email,
                    IsDoctor = user.IsDoctor
                };

                if (model.IsDoctor)
                {
                    model.FirstName = user.Doctor.FirstName;
                    model.MiddleName = user.Doctor.MiddleName;
                    model.LastName = user.Doctor.LastName;
                    model.Position = user.Doctor.Position;
                }
                else
                {
                    model.FirstName = user.Patient.FirstName;
                    model.MiddleName = user.Patient.MiddleName;
                    model.LastName = user.Patient.LastName;
                    model.PlaceWork = user.Patient.PlaceWork;
                    model.DateBirth = user.Patient.DateBirth;
                }

                return View(model);
            }

            return View("NotFound");
        }

        [HttpPost]
        public ActionResult EditAccount(EditAccountModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _authService.GetUserByLogin(User.Identity.Name);

                user.Login = model.Login;
                user.Email = model.Email;
                user.IsDoctor = model.IsDoctor;

                if (user.IsDoctor)
                {
                    user.Doctor.FirstName = model.FirstName;
                    user.Doctor.MiddleName = model.MiddleName;
                    user.Doctor.LastName = model.LastName;
                    user.Doctor.Position = model.Position;
                }
                else
                {
                    user.Patient.FirstName = model.FirstName;
                    user.Patient.MiddleName = model.MiddleName;
                    user.Patient.LastName = model.LastName;
                    user.Patient.PlaceWork = model.PlaceWork;
                    user.Patient.DateBirth = model.DateBirth;
                }

                _authService.UpdateUser(user);

                return RedirectToAction("Account", "Auth", new { login = User.Identity.Name });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult EditPassword(string login)
        {
            var user = _authService.GetUserByLogin(login);

            if (user != null)
            {
                var edit = new EditPasswordModel
                {
                    OldPassword = user.Password
                };

                return View(edit);
            }

            return View("NotFound");
        }


        [HttpPost]
        public ActionResult EditPassword(EditPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _authService.GetUserByLogin(User.Identity.Name);

                user.Password = model.NewPassword;

                _authService.UpdateUser(user);

                return RedirectToAction("Account", "Auth", new { login = User.Identity.Name });
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult CheckForDoctor(string code)
        {
            const string verificationCode = "123456";

            if (verificationCode.Equals(code))
            {
                _isDoctor = true;

                return RedirectToAction("SignUp");
            }
            else
            {
                _isDoctor = false;

                return RedirectToAction("SignUp");
            }
        }
    }
}