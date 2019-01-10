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

                return RedirectToAction("GetAllProcedures");
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

                return RedirectToAction("ProcedureDetails", procedure.Id);
            }

            return View(procedure);
        }

        [HttpPost]
        public ActionResult DeleteProcedure(int? id)
        {
            _procedureService.DeleteProcedure(id);

            return RedirectToAction("GetAllProcedures");
        }

        [HttpGet]
        public ActionResult GetAllProcedures()
        {
            var procedures = _procedureService.GetAll();

            return View(procedures);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult GetProceduresForSelect()
        {
            var procedures = _procedureService.GetAll();

            return PartialView(procedures);
        }
    }
}