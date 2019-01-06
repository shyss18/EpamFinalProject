using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;
using System.Web.Mvc;

namespace EC.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole(Role role)
        {
            if (ModelState.IsValid)
            {
                _roleService.CreateRole(role);
            }

            return View(role);
        }

        [HttpGet]
        public ActionResult UpdateRole(int? id)
        {
            var role = _roleService.GetById(id);

            if (role == null)
            {
                return View("NotFound");
            }

            return View(role);
        }

        [HttpPost]
        public ActionResult UpdateRole(Role role)
        {
            if (ModelState.IsValid)
            {
                _roleService.UpdateRole(role);
            }

            return View(role);
        }

        [HttpPost]
        public ActionResult DeleteRole(int? id)
        {
            _roleService.DeleteRole(id);

            return View();
        }

        [HttpGet]
        public ActionResult GetAllRoles()
        {
            var roles = _roleService.GetAll();

            return View(roles);
        }

        [HttpGet]
        public ActionResult GetRolesForSelect()
        {
            var roles = _roleService.GetAll();

            return PartialView(roles);
        }
    }
}