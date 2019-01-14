using EC.Common.Helpers;
using EC.Common.Helpers.Interface;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace EC.DataAccess.Repositories.Implementation
{
    public class RecordRepository : IRecordRepository
    {
        private const int DEFAULT = 0;
        private readonly ISqlFactory _factory;
        private readonly IPreparationRepository _preparationRepository;
        private readonly IProcedureRepository _procedureRepository;
        private readonly IDiagnosisRepository _diagnosisRepository;

        public RecordRepository(ISqlFactory factory, IPreparationRepository preparationRepository, IProcedureRepository procedureRepository, IDiagnosisRepository diagnosisRepository, IUserRepository userRepository)
        {
            _factory = factory;
            _preparationRepository = preparationRepository;
            _procedureRepository = procedureRepository;
            _diagnosisRepository = diagnosisRepository;
        }

        public void Create(Record item)
        {
            var dateParameter = _factory.CreateParameter("dateRecord", item.DateRecord, DbType.Date);
            var patientParameter = _factory.CreateParameter("patientId", item.PatientId, DbType.Int32);
            var diagnosisParameter = _factory.CreateParameter("diagnosisId", item.DiagnosisId, DbType.Int32);
            var doctorParameter = _factory.CreateParameter("doctorId", item.DoctorId, DbType.Int32);
            var sickLeaveParameter = _factory.CreateParameter("sickLeaveId", item.SickLeaveId, DbType.Int32);

            var id = _factory.CreateConnection()
                .CreateCommand(DbConstants.CREATE_RECORD)
                .AddParameters(dateParameter, patientParameter, diagnosisParameter, doctorParameter, sickLeaveParameter)
                .ExecuteScalar();

            if (item.Preparations != null & item.Procedures != null)
            {
                foreach (var preparation in item.Preparations)
                {
                    _preparationRepository.AddPreparationToRecord(preparation.Id, id);
                }

                foreach (var procedure in item.Procedures)
                {
                    _procedureRepository.AddProcedureToRecord(procedure.Id, id);
                }
            }
            else if (item.Procedures != null)
            {
                foreach (var procedure in item.Procedures)
                {
                    _procedureRepository.AddProcedureToRecord(procedure.Id, id);
                }
            }
            else if (item.Preparations != null)
            {
                foreach (var preparation in item.Preparations)
                {
                    _preparationRepository.AddPreparationToRecord(preparation.Id, id);
                }
            }
        }

        public void Update(Record item)
        {
            var idParameter = _factory.CreateParameter("id", item.Id, DbType.Int32);
            var dateParameter = _factory.CreateParameter("dateRecord", item.DateRecord, DbType.Date);
            var patientParameter = _factory.CreateParameter("patientId", item.PatientId, DbType.Int32);
            var diagnosisParameter = _factory.CreateParameter("diagnosisId", item.DiagnosisId, DbType.Int32);
            var doctorParameter = _factory.CreateParameter("doctorId", item.DoctorId, DbType.Int32);
            var sickLeaveParameter = _factory.CreateParameter("sickLeaveId", item.SickLeaveId, DbType.Int32);

            _factory.CreateConnection()
                .CreateCommand(DbConstants.UPDATE_RECORD)
                .AddParameters(idParameter, dateParameter, patientParameter, diagnosisParameter, doctorParameter, sickLeaveParameter)
                .ExecuteQuery();

            if (item.Preparations != null & item.Procedures != null)
            {
                DeletePreparationsRecord(item.Id);
                DeleteProceduresRecord(item.Id);

                foreach (var preparation in item.Preparations)
                {
                    _preparationRepository.AddPreparationToRecord(preparation.Id, item.Id);
                }

                foreach (var procedure in item.Procedures)
                {
                    _procedureRepository.AddProcedureToRecord(procedure.Id, item.Id);
                }
            }
            else if (item.Procedures != null)
            {
                DeleteProceduresRecord(item.Id);

                foreach (var procedure in item.Procedures)
                {
                    _procedureRepository.AddProcedureToRecord(procedure.Id, item.Id);
                }
            }
            else if (item.Preparations != null)
            {
                DeletePreparationsRecord(item.Id);

                foreach (var preparation in item.Preparations)
                {
                    _preparationRepository.AddPreparationToRecord(preparation.Id, item.Id);
                }
            }
        }

        public void Delete(int? id)
        {
            var idParameter = _factory.CreateParameter("id", id, DbType.Int32);

            _factory.CreateConnection()
                .CreateCommand(DbConstants.DELETE_RECORD)
                .AddParameters(idParameter)
                .ExecuteQuery();
        }

        public Record GetById(int? id)
        {
            var idParameter = _factory.CreateParameter("id", id, DbType.Int32);

            var reader = _factory.CreateConnection()
                .CreateCommand(DbConstants.GET_RECORD_BY_ID)
                .AddParameters(idParameter)
                .ExecuteReader();

            Record record = null;

            foreach (var item in reader)
            {
                record = new Record
                {
                    Id = (int)item["Id"],
                    DateRecord = (DateTime)item["DateRecord"],

                    PatientId = item["PatientId"] != DBNull.Value ? (int)item["PatientId"] : DEFAULT,
                    DoctorId = item["DoctorId"] != DBNull.Value ? (int)item["DoctorId"] : DEFAULT,
                    DiagnosisId = item["DiagnosisId"] != DBNull.Value ? (int)item["DiagnosisId"] : DEFAULT,
                    SickLeaveId = item["SickLeaveId"] != DBNull.Value ? (int)item["SickLeaveId"] : DEFAULT,

                    Preparations = _preparationRepository.GetPreparationsByRecordId(id),
                    Procedures = _procedureRepository.GetProceduresByRecordId(id)
                };

                if (record.PatientId != DEFAULT)
                {
                    record.Patient = new Patient
                    {
                        UserId = (int)item["PatientId"],
                        FirstName = (string)item["FirstName"],
                        MiddleName = (string)item["MiddleName"],
                        LastName = (string)item["LastName"],
                        DateBirth = (DateTime)item["DateBirth"],
                        PlaceWork = (string)item["PlaceWork"]
                    };
                }

                if (record.DoctorId != DEFAULT)
                {
                    record.Doctor = new Doctor
                    {
                        UserId = (int)item["DoctorId"],
                        FirstName = (string)item["DoctorFirstName"],
                        MiddleName = (string)item["DoctorMiddleName"],
                        LastName = (string)item["DoctorLastName"],
                        Position = (string)item["Position"]
                    };
                }

                if (record.DiagnosisId != DEFAULT)
                {
                    record.Diagnosis = new Diagnosis
                    {
                        Id = (int)item["DiagnosisId"],
                        Title = (string)item["Title"]
                    };
                }

                if (record.SickLeaveId != DEFAULT)
                {
                    record.SickLeave = new SickLeave
                    {
                        Id = (int)item["SickLeaveId"],
                        IsGive = (bool)item["IsGive"],
                        Number = (int)item["Number"],
                        PeriodAction = (int)item["PeriodAction"],
                        DiagnosisId = item["SLDiagnosisId"] != DBNull.Value ? (int)item["SLDiagnosisId"] : DEFAULT
                    };
                }

                if (record.DiagnosisId != DEFAULT)
                {
                    record.SickLeave.Diagnosis = _diagnosisRepository.GetById(record.SickLeave.DiagnosisId);
                }
            }

            return record;
        }

        public IReadOnlyCollection<Record> GetAll()
        {
            var allRecord = new List<Record>();

            var reader = _factory.CreateConnection()
                .CreateCommand(DbConstants.GET_ALL_RECORDS)
                .ExecuteReader();

            foreach (var item in reader)
            {
                var record = new Record
                {
                    Id = (int)item["Id"],
                    DateRecord = (DateTime)item["DateRecord"],

                    PatientId = item["PatientId"] != DBNull.Value ? (int)item["PatientId"] : DEFAULT,
                    DoctorId = item["DoctorId"] != DBNull.Value ? (int)item["DoctorId"] : DEFAULT,
                    DiagnosisId = item["DiagnosisId"] != DBNull.Value ? (int)item["DiagnosisId"] : DEFAULT,
                    SickLeaveId = item["SickLeaveId"] != DBNull.Value ? (int)item["SickLeaveId"] : DEFAULT
                };

                if (record.PatientId != DEFAULT)
                {
                    record.Patient = new Patient
                    {
                        UserId = (int)item["PatientId"],
                        FirstName = (string)item["FirstName"],
                        MiddleName = (string)item["MiddleName"],
                        LastName = (string)item["LastName"],
                        DateBirth = (DateTime)item["DateBirth"],
                        PlaceWork = (string)item["PlaceWork"]
                    };
                }

                if (record.DoctorId != DEFAULT)
                {
                    record.Doctor = new Doctor
                    {
                        UserId = (int)item["DoctorId"],
                        FirstName = (string)item["DoctorFirstName"],
                        MiddleName = (string)item["DoctorMiddleName"],
                        LastName = (string)item["DoctorLastName"],
                        Position = (string)item["Position"]
                    };
                }

                if (record.DiagnosisId != DEFAULT)
                {
                    record.Diagnosis = new Diagnosis
                    {
                        Id = (int)item["DiagnosisId"],
                        Title = (string)item["Title"]
                    };
                }

                if (record.SickLeaveId != DEFAULT)
                {
                    record.SickLeave = new SickLeave
                    {
                        Id = (int)item["SickLeaveId"],
                        IsGive = (bool)item["IsGive"],
                        Number = (int)item["Number"],
                        PeriodAction = (int)item["PeriodAction"],
                        DiagnosisId = item["SLDiagnosisId"] != DBNull.Value ? (int)item["SLDiagnosisId"] : DEFAULT
                    };
                }

                record.Preparations = _preparationRepository.GetPreparationsByRecordId(record.Id);
                record.Procedures = _procedureRepository.GetProceduresByRecordId(record.Id);

                allRecord.Add(record);
            }

            return allRecord;
        }

        public IReadOnlyCollection<Record> GetDoctorRecords(int? doctorId)
        {
            var idParameter = _factory.CreateParameter("userId", doctorId, DbType.Int32);

            var reader = _factory.CreateConnection()
                .CreateCommand(DbConstants.GET_DOCTOR_RECORDS)
                .AddParameters(idParameter)
                .ExecuteReader();

            var doctorRecords = new List<Record>();

            foreach (var item in reader)
            {
                var record = new Record
                {
                    Id = (int)item["Id"],
                    DateRecord = (DateTime)item["DateRecord"],

                    PatientId = item["PatientId"] != DBNull.Value ? (int)item["PatientId"] : DEFAULT,
                    DoctorId = item["DoctorId"] != DBNull.Value ? (int)item["DoctorId"] : DEFAULT,
                    DiagnosisId = item["DiagnosisId"] != DBNull.Value ? (int)item["DiagnosisId"] : DEFAULT,
                    SickLeaveId = item["SickLeaveId"] != DBNull.Value ? (int)item["SickLeaveId"] : DEFAULT
                };

                if (record.PatientId != DEFAULT)
                {
                    record.Patient = new Patient
                    {
                        UserId = (int)item["PatientId"],
                        FirstName = (string)item["FirstName"],
                        MiddleName = (string)item["MiddleName"],
                        LastName = (string)item["LastName"],
                        DateBirth = (DateTime)item["DateBirth"],
                        PlaceWork = (string)item["PlaceWork"]
                    };
                }

                if (record.DoctorId != DEFAULT)
                {
                    record.Doctor = new Doctor
                    {
                        UserId = (int)item["DoctorId"],
                        FirstName = (string)item["DoctorFirstName"],
                        MiddleName = (string)item["DoctorMiddleName"],
                        LastName = (string)item["DoctorLastName"],
                        Position = (string)item["Position"]
                    };
                }

                if (record.DiagnosisId != DEFAULT)
                {
                    record.Diagnosis = new Diagnosis
                    {
                        Id = (int)item["DiagnosisId"],
                        Title = (string)item["Title"]
                    };
                }

                if (record.SickLeaveId != DEFAULT)
                {
                    record.SickLeave = new SickLeave
                    {
                        Id = (int)item["SickLeaveId"],
                        IsGive = (bool)item["IsGive"],
                        Number = (int)item["Number"],
                        PeriodAction = (int)item["PeriodAction"],
                        DiagnosisId = item["SLDiagnosisId"] != DBNull.Value ? (int)item["SLDiagnosisId"] : DEFAULT
                    };
                }

                record.Preparations = _preparationRepository.GetPreparationsByRecordId(doctorId);
                record.Procedures = _procedureRepository.GetProceduresByRecordId(doctorId);

                doctorRecords.Add(record);
            }

            return doctorRecords;
        }

        public IReadOnlyCollection<Record> GetPatientRecords(int? patientId)
        {
            var idParameter = _factory.CreateParameter("userId", patientId, DbType.Int32);

            var reader = _factory.CreateConnection()
                .CreateCommand(DbConstants.GET_PATIENT_RECORDS)
                .AddParameters(idParameter)
                .ExecuteReader();

            var patientRecords = new List<Record>();

            foreach (var item in reader)
            {
                var record = new Record
                {
                    Id = (int)item["Id"],
                    DateRecord = (DateTime)item["DateRecord"],

                    PatientId = item["PatientId"] != DBNull.Value ? (int)item["PatientId"] : DEFAULT,
                    DoctorId = item["DoctorId"] != DBNull.Value ? (int)item["DoctorId"] : DEFAULT,
                    DiagnosisId = item["DiagnosisId"] != DBNull.Value ? (int)item["DiagnosisId"] : DEFAULT,
                    SickLeaveId = item["SickLeaveId"] != DBNull.Value ? (int)item["SickLeaveId"] : DEFAULT
                };

                if (record.PatientId != DEFAULT)
                {
                    record.Patient = new Patient
                    {
                        UserId = (int)item["PatientId"],
                        FirstName = (string)item["FirstName"],
                        MiddleName = (string)item["MiddleName"],
                        LastName = (string)item["LastName"],
                        DateBirth = (DateTime)item["DateBirth"],
                        PlaceWork = (string)item["PlaceWork"]
                    };
                }

                if (record.DoctorId != DEFAULT)
                {
                    record.Doctor = new Doctor
                    {
                        UserId = (int)item["DoctorId"],
                        FirstName = (string)item["DoctorFirstName"],
                        MiddleName = (string)item["DoctorMiddleName"],
                        LastName = (string)item["DoctorLastName"],
                        Position = (string)item["Position"]
                    };
                }

                if (record.DiagnosisId != DEFAULT)
                {
                    record.Diagnosis = new Diagnosis
                    {
                        Id = (int)item["DiagnosisId"],
                        Title = (string)item["Title"]
                    };
                }

                if (record.SickLeaveId != DEFAULT)
                {
                    record.SickLeave = new SickLeave
                    {
                        Id = (int)item["SickLeaveId"],
                        IsGive = (bool)item["IsGive"],
                        Number = (int)item["Number"],
                        PeriodAction = (int)item["PeriodAction"],
                        DiagnosisId = item["SLDiagnosisId"] != DBNull.Value ? (int)item["SLDiagnosisId"] : DEFAULT
                    };
                }

                record.Preparations = _preparationRepository.GetPreparationsByRecordId(patientId);
                record.Procedures = _procedureRepository.GetProceduresByRecordId(patientId);

                patientRecords.Add(record);
            }

            return patientRecords;
        }

        private void DeletePreparationsRecord(int? recordId)
        {
            var recordParameter = _factory.CreateParameter("recordId", recordId, DbType.Int32);

            _factory.CreateConnection()
                .CreateCommand(DbConstants.DELETE_PREPARATIONS_RECORD)
                .AddParameters(recordParameter)
                .ExecuteQuery();
        }

        private void DeleteProceduresRecord(int? recordId)
        {
            var recordParameter = _factory.CreateParameter("recordId", recordId, DbType.Int32);

            _factory.CreateConnection()
                .CreateCommand(DbConstants.DELETE_PROCEDURES_RECORD)
                .AddParameters(recordParameter)
                .ExecuteQuery();
        }
    }
}
