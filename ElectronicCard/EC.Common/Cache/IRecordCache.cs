using EC.Entities.Entities;

namespace EC.Common.Cache
{
    public interface IRecordCache
    {
        bool Create(Record value);
        void Update(Record value);
        void Delete(int? id);
        Record GetCache(int? id);
    }
}
