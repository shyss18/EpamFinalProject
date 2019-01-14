using System.Collections.Generic;
using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Interfaces
{
    public interface IProcedureRepository : IRepository<Procedure>
    {
        void AddProcedureToRecord(int? procedureId, int? recordId);
        IReadOnlyCollection<Procedure> GetProceduresByRecordId(int? recordId);
    }
}
