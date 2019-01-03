using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using System.Collections.Generic;

namespace EC.BusinessLogic.Services.Implementation
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordRepository;

        public RecordService(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public void CreateRecord(Record record)
        {
            _recordRepository.Create(record);
        }

        public void UpdateRecord(Record record)
        {
            _recordRepository.Update(record);
        }

        public void DeleteRecord(int? id)
        {
            _recordRepository.Delete(id);
        }

        public Record GetRecordById(int? id)
        {
            return id == null ? null : _recordRepository.GetById(id);
        }

        public IReadOnlyCollection<Record> GetAllRecords()
        {
            return _recordRepository.GetAll();
        }

        public IReadOnlyCollection<Record> GetRecordsByPatientId(int? id)
        {
            return id == null ? null : _recordRepository.GetPatientRecords(id);
        }

        public IReadOnlyCollection<Record> GetRecordsByDoctorId(int? id)
        {
            return id == null ? null : _recordRepository.GetDoctorRecords(id);
        }
    }
}
