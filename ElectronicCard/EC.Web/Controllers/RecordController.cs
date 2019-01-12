using System;
using System.Collections.Generic;
using System.Linq;
using EC.BusinessLogic.Services.Interfaces;
using EC.Entities.Entities;
using System.Web.Mvc;
using EC.Common.Cache;
using EC.Web.Models;

namespace EC.Web.Controllers
{
    public class RecordController : Controller
    {
        private readonly IRecordCache _cache;
        private readonly IRecordService _recordService;
        private readonly IPreparationService _preparationService;
        private readonly IProcedureService _procedureService;
        private readonly IUserService _userService;

        public RecordController(IRecordService recordService, IPreparationService preparationService, IProcedureService procedureService, IUserService userService, IRecordCache cache)
        {
            _recordService = recordService;
            _preparationService = preparationService;
            _procedureService = procedureService;
            _userService = userService;
            _cache = cache;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Editor, Doctor")]
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

                return RedirectToAction("GetDoctorRecords", "Record", new { login = User.Identity.Name });
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult EditRecord(int? id)
        {
            var record = _cache.GetCache(id);

            if (record == null)
            {
                record = _recordService.GetRecordById(id);
                _cache.Create(record);
            }

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
                var record = _cache.GetCache(model.Id);

                if (record == null)
                {
                    record = _recordService.GetRecordById(model.Id);
                    _cache.Create(record);
                }

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
                _cache.Update(record);

                return RedirectToAction("DetailsRecord", new { id = record.Id });
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult DetailsRecord(int? id)
        {
            var record = _cache.GetCache(id);

            if (record == null)
            {
                record = _recordService.GetRecordById(id);
                _cache.Create(record);
            }

            return record == null ? View("NotFound") : View(record);
        }

        [HttpPost]
        public ActionResult DeleteRecord(int? id)
        {
            _recordService.DeleteRecord(id);
            _cache.Delete(id);

            if (User.IsInRole("Admin") || User.IsInRole("Editor"))
            {
                return RedirectToAction("GetAllRecords");
            }

            return RedirectToAction("GetDoctorsRecords", User.Identity.Name);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult GetAllRecords()
        {
            var records = _recordService.GetAllRecords();

            return View(records);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Editor, User")]
        public ActionResult GetPatientRecords(string login)
        {
            var records = _recordService.GetPatientRecords(login);

            return records == null ? View("NotFound") : View("GetAllRecords", records);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Editor, Doctor")]
        public ActionResult GetDoctorRecords(string login)
        {
            var records = _recordService.GetDoctorRecords(login);

            return records == null ? View("NotFound") : View("GetAllRecords", records);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchBy, string search)
        {
            IReadOnlyCollection<Record> records;

            if (User.IsInRole("Admin") || User.IsInRole("Editor"))
            {
                switch (searchBy)
                {
                    case "Date":

                        if (DateTime.TryParse(search, out var check))
                        {
                            records = _recordService.GetAllRecords().Where(r => r.DateRecord == check).ToList();

                            return PartialView("Records", records);
                        }

                        break;
                    case "Diagnosis":

                        records = _recordService.GetAllRecords().Where(r => r.Diagnosis.Title == search).ToList();

                        return PartialView("Records", records);
                    case "Position":

                        records = _recordService.GetAllRecords().Where(r => r.Doctor.Position == search).ToList();

                        return PartialView("Records", records);
                }
            }
            else if (User.IsInRole("Doctor"))
            {
                switch (searchBy)
                {
                    case "Date":

                        if (DateTime.TryParse(search, out var check))
                        {
                            records = _recordService.GetDoctorRecords(User.Identity.Name).Where(r => r.DateRecord == check).ToList();

                            return PartialView("Records", records);
                        }

                        break;
                    case "Diagnosis":

                        records = _recordService.GetDoctorRecords(User.Identity.Name).Where(r => r.Diagnosis.Title == search).ToList();

                        return PartialView("Records", records);
                    case "Position":

                        records = _recordService.GetDoctorRecords(User.Identity.Name).Where(r => r.Doctor.Position == search).ToList();

                        return PartialView("Records", records);
                }
            }
            else
            {
                switch (searchBy)
                {
                    case "Date":

                        if (DateTime.TryParse(search, out var check))
                        {
                            records = _recordService.GetPatientRecords(User.Identity.Name).Where(r => r.DateRecord == check).ToList();

                            return PartialView("Records", records);
                        }

                        break;
                    case "Diagnosis":

                        records = _recordService.GetPatientRecords(User.Identity.Name).Where(r => r.Diagnosis.Title == search).ToList();

                        return PartialView("Records", records);
                    case "Position":

                        records = _recordService.GetPatientRecords(User.Identity.Name).Where(r => r.Doctor.Position == search).ToList();

                        return PartialView("Records", records);
                }
            }

            return PartialView("Records");
        }

        [HttpGet]
        public JsonResult CheckDate(string DateRecord)
        {
            if (!DateTime.TryParse(DateRecord, out var parsedDate))
            {
                return Json("Пожалуйста, введите дату в формате (мм.дд.гггг)",
                    JsonRequestBehavior.AllowGet);
            }

            if (DateTime.Now < parsedDate)
            {
                return Json("Введите дату не относящуюся к будущему",
                    JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}