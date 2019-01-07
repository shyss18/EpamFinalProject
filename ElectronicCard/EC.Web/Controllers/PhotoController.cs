using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;
using EC.Web.Models;

namespace EC.Web.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpGet]
        public ActionResult EditPhoto(string login)
        {
            var photo = _photoService.GetUserPhoto(login);

            var editPhoto = new EditPhotoModel
            {
                Id = photo.Id,
                UserPhoto = photo,
                UserId = photo.UserId
            };

            return View(editPhoto);
        }

        [HttpPost]
        public ActionResult EditPhoto(EditPhotoModel model)
        {
            if (model.Image != null)
            {
                var photo = _photoService.GetUserPhoto(User.Identity.Name);

                photo.Image = new byte[model.Image.ContentLength];
                photo.ImageType = model.Image.ContentType;

                model.Image.InputStream.Read(photo.Image, 0, model.Image.ContentLength);

                _photoService.UpdatePhoto(photo);

                return RedirectToAction("Account", "Auth", new { login = User.Identity.Name });
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult DeletePhoto(int? id)
        {
            _photoService.DeletePhoto(id);

            return RedirectToAction("Account", "Auth", new { login = User.Identity.Name });
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