using System.Collections.Generic;
using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Interfaces
{
    public interface IRecordRepository : IRepository<Record>
    {
        IReadOnlyCollection<Record> GetDoctorRecords(int? doctorId);
        IReadOnlyCollection<Record> GetPatientRecords(int? patientId);
    }
}
