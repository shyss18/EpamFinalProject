using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EC.BusinessLogic.Services.Interfaces;

namespace EC.Web.Controllers
{
    public class PromotionController : Controller
    {
        private readonly IPromotionService _service;

        public PromotionController(IPromotionService service)
        {
            _service = service;
        }

        public string Test()
        {
            var result = _service.TestConnection();

            return result;
        }

    }
}