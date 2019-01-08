using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;
using System.Web.Mvc;
using EC.Web.Models;

namespace EC.Web.Controllers
{
    public class RecordController : Controller
    {
        private readonly IRecordService _recordService;
        private readonly IPreparationService _preparationService;
        private readonly IProcedureService _procedureService;

        public RecordController(IRecordService recordService, IPreparationService preparationService, IProcedureService procedureService)
        {
            _recordService = recordService;
            _preparationService = preparationService;
            _procedureService = procedureService;
        }

        [HttpGet]
        public ActionResult CreateRecord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRecord(CreateRecordModel model)
        {
            if (ModelState.IsValid)
            {
                var record = new Record
                {
                    DateRecord = model.DateRecord,
                    DiagnosisId = model.DiagnosisId,
                    PatientId = model.PatientId,
                    DoctorId = model.DoctorId,
                    SickLeaveId = model.SickLeaveId,

                };

                _recordService.CreateRecord(record);

                return RedirectToAction("GetAllRecords");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult UpdateRecord(int? id)
        {
            var record = _recordService.GetRecordById(id);

            return record == null ? View("NotFound") : View(record);
        }

        [HttpPost]
        public ActionResult UpdateRecord(Record record)
        {
            if (ModelState.IsValid)
            {
                _recordService.UpdateRecord(record);
            }

            return View(record);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var record = _recordService.GetRecordById(id);

            return record == null ? View("NotFound") : View(record);
        }

        [HttpPost]
        public ActionResult DeleteRecord(int? id)
        {
            _recordService.DeleteRecord(id);

            return View();
        }

        [HttpGet]
        public ActionResult GetAllRecords()
        {
            var records = _recordService.GetAllRecords();

            return View(records);
        }

        [HttpGet]
        public ActionResult GetPatientRecords(int? id)
        {
            var records = _recordService.GetRecordsByPatientId(id);

            return records == null ? View("NotFound") : View(records);
        }

        [HttpGet]
        public ActionResult GetDoctorsRecords(int? id)
        {
            var records = _recordService.GetRecordsByDoctorId(id);

            return records == null ? View("NotFound") : View(records);
        }
    }
}