using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;
using System.Web.Mvc;

namespace EC.Web.Controllers
{
    public class ProcedureController : Controller
    {
        private readonly IProcedureService _procedureService;

        public ProcedureController(IProcedureService procedureService)
        {
            _procedureService = procedureService;
        }

        [HttpGet]
        public ActionResult CreateProcedure()
        {
           return View();
        }
        
        [HttpPost]
        public ActionResult CreateProcedure(Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                _procedureService.CreateProcedure(procedure);
            }

            return View(procedure);
        }

        [HttpGet]
        public ActionResult ProcedureDetails(int? id)
        {
            var procedure = _procedureService.GetById(id);

            if (procedure == null)
            {
                return HttpNotFound();
            }

            return View(procedure);
        }

        [HttpGet]
        public ActionResult UpdateProcedure(int? id)
        {
            var procedure = _procedureService.GetById(id);

            if (procedure == null)
            {
                return View("NotFound");
            }

            return View(procedure);
        }

        [HttpPost]
        public ActionResult UpdateProcedure(Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                _procedureService.UpdateProcedure(procedure);
            }

            return View(procedure);
        }

        [HttpPost]
        public ActionResult DeleteProcedure(int? id)
        {
            _procedureService.DeleteProcedure(1);

            return View();

        }

        [HttpGet]
        public ActionResult GetAllProcedure()
        {
            var procedures = _procedureService.GetAll();

            return View(procedures);
        }
    }
}