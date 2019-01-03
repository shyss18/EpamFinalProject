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
        private readonly ISqlFactory _factory;
        private readonly IPreparationRepository _preparationRepository;
        private readonly IProcedureRepository _procedureRepository;

        public RecordRepository(ISqlFactory factory, IPreparationRepository preparationRepository, IProcedureRepository procedureRepository)
        {
            _factory = factory;
            _preparationRepository = preparationRepository;
            _procedureRepository = procedureRepository;
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

            if (item.Preparations.Count > 0 & item.Procedures.Count > 0)
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
            else if (item.Procedures.Count > 0)
            {
                foreach (var procedure in item.Procedures)
                {
                    _procedureRepository.AddProcedureToRecord(procedure.Id, id);
                }
            }
            else
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

            if (item.Preparations.Count > 0 & item.Procedures.Count > 0)
            {
                foreach (var preparation in item.Preparations)
                {
                    _preparationRepository.Update(preparation);
                }

                foreach (var procedure in item.Procedures)
                {
                    _procedureRepository.Update(procedure);
                }
            }
            else if (item.Procedures.Count > 0)
            {
                foreach (var procedure in item.Procedures)
                {
                    _procedureRepository.Update(procedure);
                }
            }
            else
            {
                foreach (var preparation in item.Preparations)
                {
                    _preparationRepository.Update(preparation);
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

                    PatientId = (int)item["PatientId"],
                    Patient =
                        new Patient
                        {
                            UserId = (int)item["PatientId"],
                            FirstName = (string)item["FirstName"],
                            MiddleName = (string)item["MiddleName"],
                            LastName = (string)item["LastName"],
                            DateBirth = (DateTime)item["DateBirth"],
                            PlaceWork = (string)item["PlaceWork"]
                        },

                    DoctorId = (int)item["DoctorId"],
                    Doctor =
                        new Doctor
                        {
                            UserId = (int)item["DoctorId"],
                            FirstName = (string)item["FirstName"],
                            MiddleName = (string)item["MiddleName"],
                            LastName = (string)item["LastName"],
                            Position = (string)item["Position"]
                        },

                    DiagnosisId = (int)item["DiagnosisId"],
                    Diagnosis = new Diagnosis
                    {
                        Id = (int)item["DiagnosisId"],
                        Title = (string)item["Title"]
                    },

                    SickLeaveId = (int)item["SickLeaveId"],
                    SickLeave = new SickLeave
                    {
                        Id = (int)item["SickLeaveId"],
                        IsGive = (bool)item["IsGive"],
                        Number = (int)item["Number"],
                        PeriodAction = (int)item["PeriodAction"]
                    },

                    Preparations = _preparationRepository.GetPreparationsByRecordId(id),
                    Procedures = _procedureRepository.GetProceduresByRecordId(id)
                };
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

                    PatientId = (int)item["PatientId"],
                    Patient =
                        new Patient
                        {
                            UserId = (int)item["PatientId"],
                            FirstName = (string)item["FirstName"],
                            MiddleName = (string)item["MiddleName"],
                            LastName = (string)item["LastName"],
                            DateBirth = (DateTime)item["DateBirth"],
                            PlaceWork = (string)item["PlaceWork"]
                        },

                    DoctorId = (int)item["DoctorId"],
                    Doctor =
                        new Doctor
                        {
                            UserId = (int)item["DoctorId"],
                            FirstName = (string)item["FirstName"],
                            MiddleName = (string)item["MiddleName"],
                            LastName = (string)item["LastName"],
                            Position = (string)item["Position"]
                        },

                    DiagnosisId = (int)item["DiagnosisId"],
                    Diagnosis = new Diagnosis
                    {
                        Id = (int)item["DiagnosisId"],
                        Title = (string)item["Title"]
                    },

                    SickLeaveId = (int)item["SickLeaveId"],
                    SickLeave = new SickLeave
                    {
                        Id = (int)item["SickLeaveId"],
                        IsGive = (bool)item["IsGive"],
                        Number = (int)item["Number"],
                        PeriodAction = (int)item["PeriodAction"]
                    },
                };

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

                    PatientId = (int)item["PatientId"],
                    Patient =
                        new Patient
                        {
                            UserId = (int)item["PatientId"],
                            FirstName = (string)item["FirstName"],
                            MiddleName = (string)item["MiddleName"],
                            LastName = (string)item["LastName"],
                            DateBirth = (DateTime)item["DateBirth"],
                            PlaceWork = (string)item["PlaceWork"]
                        },

                    DoctorId = (int)item["DoctorId"],
                    Doctor =
                        new Doctor
                        {
                            UserId = (int)item["DoctorId"],
                            FirstName = (string)item["FirstName"],
                            MiddleName = (string)item["MiddleName"],
                            LastName = (string)item["LastName"],
                            Position = (string)item["Position"]
                        },

                    DiagnosisId = (int)item["DiagnosisId"],
                    Diagnosis = new Diagnosis
                    {
                        Id = (int)item["DiagnosisId"],
                        Title = (string)item["Title"]
                    },

                    SickLeaveId = (int)item["SickLeaveId"],
                    SickLeave = new SickLeave
                    {
                        Id = (int)item["SickLeaveId"],
                        IsGive = (bool)item["IsGive"],
                        Number = (int)item["Number"],
                        PeriodAction = (int)item["PeriodAction"]
                    },
                };

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

            var doctorRecords = new List<Record>();

            foreach (var item in reader)
            {
                var record = new Record
                {
                    Id = (int)item["Id"],
                    DateRecord = (DateTime)item["DateRecord"],

                    PatientId = (int)item["PatientId"],
                    Patient =
                        new Patient
                        {
                            UserId = (int)item["PatientId"],
                            FirstName = (string)item["FirstName"],
                            MiddleName = (string)item["MiddleName"],
                            LastName = (string)item["LastName"],
                            DateBirth = (DateTime)item["DateBirth"],
                            PlaceWork = (string)item["PlaceWork"]
                        },

                    DoctorId = (int)item["DoctorId"],
                    Doctor =
                        new Doctor
                        {
                            UserId = (int)item["DoctorId"],
                            FirstName = (string)item["FirstName"],
                            MiddleName = (string)item["MiddleName"],
                            LastName = (string)item["LastName"],
                            Position = (string)item["Position"]
                        },

                    DiagnosisId = (int)item["DiagnosisId"],
                    Diagnosis = new Diagnosis
                    {
                        Id = (int)item["DiagnosisId"],
                        Title = (string)item["Title"]
                    },

                    SickLeaveId = (int)item["SickLeaveId"],
                    SickLeave = new SickLeave
                    {
                        Id = (int)item["SickLeaveId"],
                        IsGive = (bool)item["IsGive"],
                        Number = (int)item["Number"],
                        PeriodAction = (int)item["PeriodAction"]
                    },
                };

                record.Preparations = _preparationRepository.GetPreparationsByRecordId(patientId);
                record.Procedures = _procedureRepository.GetProceduresByRecordId(patientId);

                doctorRecords.Add(record);
            }

            return doctorRecords;
        }
    }
}
