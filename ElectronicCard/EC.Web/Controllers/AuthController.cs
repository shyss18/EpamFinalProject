using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;
using EC.Web.Models;
using System.Collections.Generic;
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
        [ValidateAntiForgeryToken]
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

            ModelState.AddModelError("", "Неверный логин или пароль");
            return View(signIn);
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            ViewBag.IsDoctor = _isDoctor;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(RegistrationModel registration)
        {
            ViewBag.IsDoctor = _isDoctor;

            if (registration.Photo != null && !registration.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("", "Выберете файл изображения");
            }

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Login = registration.Login,
                    Password = registration.Password,
                    Email = registration.Email,
                    IsDoctor = registration.IsDoctor,
                    PhoneNumbers = new List<Phone>
                    {
                        new Phone
                        {
                            PhoneNumber = registration.PhoneNumber
                        }
                    }
                };

                if (_isDoctor)
                {
                    user.Doctor = new Doctor
                    {
                        FirstName = registration.FirstName,
                        MiddleName = registration.MiddleName,
                        LastName = registration.LastName,
                        Position = registration.Position,
                    };
                }
                else
                {
                    user.Patient = new Patient
                    {
                        FirstName = registration.FirstName,
                        MiddleName = registration.MiddleName,
                        LastName = registration.LastName,
                        PlaceWork = registration.PlaceWork,
                        DateBirth = registration.DateBirth
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
        [Authorize]
        public ActionResult Account(string login)
        {
            var user = _authService.GetUserByLogin(login);

            if (user == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(user);
        }

        [HttpGet]
        [Authorize]
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

            return RedirectToAction("NotFound", "Error");
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
        [Authorize(Roles = "Admin")]
        public ActionResult EditVerificationCode()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditVerificationCode(EditVerificationCodeModel model)
        {
            if (ModelState.IsValid)
            {
                _authService.EditVerificationCode(model.NewCode);

                return RedirectToAction("Account", "Auth", new { login = User.Identity.Name });
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
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

            return RedirectToAction("NotFound", "Error");
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

            }

            return RedirectToAction("SignUp");
        }

        [HttpGet]
        public JsonResult CheckLogin(string Login)
        {
            var result = _authService.GetUserByLogin(Login);

            if (result != null & User.Identity.Name != Login)
            {
                return Json("Данный логин уже занят", JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CheckEmail(string Email)
        {
            var result = _authService.GetUserByEmail(Email);
            var checkUser = _authService.GetUserByLogin(User.Identity.Name);

            if (checkUser == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            if (result != null & checkUser.Email == Email)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            if (result != null & checkUser.Email != Email)
            {
                return Json("Пользователь с таким адресом уже зарегистрирован", JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CheckPassword(string NewPassword)
        {
            var user = _authService.GetUserByLogin(User.Identity.Name);

            if (user == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            if (user.Password == NewPassword)
            {
                return Json("Новый пароль не может быть старым", JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}