using EC.BusinessLogic.Services.Interfaces;
using EC.Web.Models;
using System.Web.Mvc;
using EC.Entities.Entities;

namespace EC.Web.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IUserService _userService;

        public PhotoController(IPhotoService photoService, IUserService userService)
        {
            _photoService = photoService;
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditPhoto(string login)
        {
            var photo = _photoService.GetUserPhoto(login);
            var user = _userService.GetUserByLogin(login);

            if (photo != null)
            {
                var editPhoto = new EditPhotoModel
                {
                    Id = photo.Id,
                    UserPhoto = photo,
                    UserId = photo.UserId,
                    UserLogin = user.Login
                };

                return View(editPhoto);
            }
            else
            {
                var editPhoto = new EditPhotoModel
                {
                    Id = 0,
                    UserPhoto = null,
                    UserId = 0
                };

                return View(editPhoto);
            }
        }

        [HttpPost]
        public ActionResult EditPhoto(EditPhotoModel model)
        {
            if (model.Image != null && !model.Image.ContentType.Contains("image"))
            {
                ModelState.AddModelError("", "Выберете файл изображения");
            }

            if (model.Image != null)
            {
                var photo = _photoService.GetUserPhoto(User.Identity.Name);

                if (photo != null)
                {
                    photo.Image = new byte[model.Image.ContentLength];
                    photo.ImageType = model.Image.ContentType;

                    model.Image.InputStream.Read(photo.Image, 0, model.Image.ContentLength);

                    _photoService.UpdatePhoto(photo);

                    return RedirectToAction("Account", "Auth", new { login = User.Identity.Name });
                }
                else
                {
                    var user = _userService.GetUserByLogin(User.Identity.Name);

                    var createPhoto = new Photo
                    {
                        Image = new byte[model.Image.ContentLength],
                        ImageType = model.Image.ContentType,
                        UserId = user.Id
                    };

                    model.Image.InputStream.Read(createPhoto.Image, 0, model.Image.ContentLength);

                    _photoService.CreatePhoto(createPhoto);

                    return RedirectToAction("Account", "Auth", new { login = User.Identity.Name });
                }
            }

            return View(model);
        }

        public FileContentResult GetImage(string login)
        {
            var photo = _photoService.GetUserPhoto(login);

            if (photo != null)
            {
                return File(photo.Image, photo.ImageType);
            }

            return null;
        }
    }
}