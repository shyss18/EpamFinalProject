using EC.Entities.Entities;
using System.Collections.Generic;

namespace EC.BusinessLogic.Services.Interfaces
{
    public interface IRecordService
    {
        void CreateRecord(Record record);
        void UpdateRecord(Record record);
        void DeleteRecord(int? id);
        Record GetRecordById(int? id);
        IReadOnlyCollection<Record> GetAllRecords();
        IReadOnlyCollection<Record> GetPatientRecords(string login);
        IReadOnlyCollection<Record> GetDoctorRecords(string login);
    }
}
