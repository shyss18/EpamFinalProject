using System.Collections.Generic;
using System.Linq;
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
        private readonly IUserService _userService;

        public RecordController(IRecordService recordService, IPreparationService preparationService, IProcedureService procedureService, IUserService userService)
        {
            _recordService = recordService;
            _preparationService = preparationService;
            _procedureService = procedureService;
            _userService = userService;
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
                    SickLeaveId = model.SickLeaveId
                };

                if (model.Procedures != null)
                {
                    record.Procedures = _procedureService.GetAll().Where(p => model.Procedures.Contains(p.Id)).ToList();
                }

                if (model.Preparations != null)
                {
                    record.Preparations = _preparationService.GetAll().Where(p => model.Preparations.Contains(p.Id))
                        .ToList();
                }

                _recordService.CreateRecord(record);

                if (User.IsInRole("Admin") || User.IsInRole("Editor"))
                {
                    return RedirectToAction("GetAllRecords");
                }

                return RedirectToAction("GetDoctorsRecords", User.Identity.Name);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult EditRecord(int? id)
        {
            var record = _recordService.GetRecordById(id);

            if (record != null)
            {
                var edit = new EditRecordModel
                {
                    Id = record.Id,
                    DateRecord = record.DateRecord,
                    PatientId = record.PatientId,
                    Patient = _userService.GetUserById(record.PatientId).Patient,
                    DiagnosisId = record.DiagnosisId,
                    DoctorId = record.DoctorId,
                    Doctor = _userService.GetUserById(record.DoctorId).Doctor,
                    SickLeaveId = record.SickLeaveId,
                    Procedures = record.Procedures.Select(p => p.Id).ToArray(),
                    Preparations = record.Preparations.Select(p => p.Id).ToArray()
                };

                return View(edit);
            }

            return View("NotFound");
        }

        [HttpPost]
        public ActionResult EditRecord(EditRecordModel model)
        {
            if (ModelState.IsValid)
            {
                var record = _recordService.GetRecordById(model.Id);

                record.DateRecord = model.DateRecord;
                record.PatientId = model.PatientId;
                record.DoctorId = model.DoctorId;
                record.DiagnosisId = model.DiagnosisId;
                record.SickLeaveId = model.SickLeaveId;

                if (model.Preparations == null)
                {
                    record.Preparations = new List<Preparation>();
                }

                if (model.Procedures == null)
                {
                    record.Procedures = new List<Procedure>();
                }

                if (model.Procedures != null)
                {
                    record.Procedures = _procedureService.GetAll().Where(p => model.Procedures.Contains(p.Id)).ToList();
                }

                if (model.Preparations != null)
                {
                    record.Preparations = _preparationService.GetAll().Where(p => model.Preparations.Contains(p.Id))
                        .ToList();
                }

                _recordService.UpdateRecord(record);

                return RedirectToAction("DetailsRecord", new { id = record.Id });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult DetailsRecord(int? id)
        {
            var record = _recordService.GetRecordById(id);

            return record == null ? View("NotFound") : View(record);
        }

        [HttpPost]
        public ActionResult DeleteRecord(int? id)
        {
            _recordService.DeleteRecord(id);

            if (User.IsInRole("Admin") || User.IsInRole("Editor"))
            {
                return RedirectToAction("GetAllRecords");
            }

            return RedirectToAction("GetDoctorsRecords", User.Identity.Name);
        }

        [HttpGet]
        public ActionResult GetAllRecords()
        {
            var records = _recordService.GetAllRecords();

            return View(records);
        }

        [HttpGet]
        public ActionResult GetPatientRecords(string login)
        {
            var records = _recordService.GetPatientRecords(login);

            return records == null ? View("NotFound") : View(records);
        }

        [HttpGet]
        public ActionResult GetDoctorsRecords(string login)
        {
            var records = _recordService.GetDoctorRecords(login);

            return records == null ? View("NotFound") : View(records);
        }
    }
}