using EC.Entities.Entities;
using System;
using System.Runtime.Caching;

namespace EC.Common.Cache
{
    public class RecordCache : IRecordCache
    {
        private readonly MemoryCache _memoryCache;

        public RecordCache()
        {
            _memoryCache = new MemoryCache("RecordCache");
        }

        public bool Create(Record value)
        {
            if (value == null)
            {
                return false;
            }

            return _memoryCache.Add(value.Id.ToString(), value, DateTime.Now.AddMinutes(10));
        }

        public void Update(Record value)
        {
            if (value == null)
            {
                return;
            }

            _memoryCache.Set(value.Id.ToString(), value, DateTime.Now.AddMinutes(10));
        }

        public void Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return;
            }

            if (_memoryCache.Contains(id.ToString()))
            {
                _memoryCache.Remove(id.ToString());
            }
        }

        public Record GetCache(int? id)
        {
            if (id == null || id <= 0)
            {
                return null;
            }

            return _memoryCache.Get(id.ToString()) as Record;
        }
    }
}
