using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EC.BusinessLogic.Services.Interfaces;

namespace EC.Web.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        //[HttpPost]
        //public ActionResult CreatePhoto(HttpPostedFileBase photo)
        //{
        //    if (photo != null)
        //    {
                
        //    }
        //}
    }
}