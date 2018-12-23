using System.Web.Mvc;
using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;

namespace EC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IPreparationService _preparationService;
        private readonly IProcedureService _procedureService;

        public HomeController(IRoleService roleService, IPreparationService preparationService, IProcedureService procedureService)
        {
            _roleService = roleService;
            _preparationService = preparationService;
            _procedureService = procedureService;
        }

        public ActionResult Index()
        {
            _roleService.GetAll();


            return View();
        }
    }
}