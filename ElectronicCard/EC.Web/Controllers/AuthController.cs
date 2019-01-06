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

        public AuthController(IAuthService authService)
        {
            _authService = authService;
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
                    var fileName = Path.GetFileName(registration.Photo.FileName);

                    Directory.CreateDirectory(Server.MapPath("~/Photos/"));

                    registration.Photo.SaveAs(Server.MapPath("~/Photos/" + fileName));

                    user.Photo = new Photo
                    {
                        Path = Path.GetFullPath(Server.MapPath("~/Photos/" + fileName))
                    };
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