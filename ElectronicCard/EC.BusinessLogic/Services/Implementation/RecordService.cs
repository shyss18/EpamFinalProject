using System;
using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EC.BusinessLogic.Services.Implementation
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordRepository;
        private readonly IUserRepository _userRepository;

        public RecordService(IRecordRepository recordRepository, IUserRepository userRepository)
        {
            _recordRepository = recordRepository;
            _userRepository = userRepository;
        }

        public void CreateRecord(Record record)
        {
            _recordRepository.Create(record);

            var user = _userRepository.GetById(record.DoctorId);

            if (user != null)
            {
                if (user.Doctor.Patients.FirstOrDefault(p => p.Id == record.PatientId) == null)
                {
                    _userRepository.AddPatientToDoctor(record.PatientId, user.Id);
                }
            }
        }

        public void UpdateRecord(Record record)
        {
            if (record != null)
            {
                _recordRepository.Update(record);
            }
            else
            {
                throw new NullReferenceException();
            }
            
        }

        public void DeleteRecord(int? id)
        {
            if (id <= 0 || id == null)
            {
                return;
            }

            _recordRepository.Delete(id);
        }

        public Record GetRecordById(int? id)
        {
            return id == null || id <= 0 ? null : _recordRepository.GetById(id);
        }

        public IReadOnlyCollection<Record> GetAllRecords()
        {
            return _recordRepository.GetAll();
        }

        public IReadOnlyCollection<Record> GetPatientRecords(string login)
        {
            var user = _userRepository.GetUserByLogin(login);

            return user == null ? null : _recordRepository.GetPatientRecords(user.Id);
        }

        public IReadOnlyCollection<Record> GetDoctorRecords(string login)
        {
            var user = _userRepository.GetUserByLogin(login);

            return user == null ? null : _recordRepository.GetDoctorRecords(user.Id);
        }
    }
}
