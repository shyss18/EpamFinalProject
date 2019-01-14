using System.Collections.Generic;
using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Interfaces
{
    public interface IPreparationRepository: IRepository<Preparation>
    {
        void AddPreparationToRecord(int? preparationId, int? recordId);
        IReadOnlyCollection<Preparation> GetPreparationsByRecordId(int? recordId);
    }
}
