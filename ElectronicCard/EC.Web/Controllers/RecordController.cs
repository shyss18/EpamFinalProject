using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;
using System.Web.Mvc;

namespace EC.Web.Controllers
{
    public class RecordController : Controller
    {
        private readonly IRecordService _recordService;

        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpGet]
        public ActionResult CreateRecord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRecord(Record record)
        {
            if (ModelState.IsValid)
            {
                _recordService.CreateRecord(record);
            }

            return View(record);
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