using System.Collections.Generic;

namespace EC.Entities.Entities
{
    public class Preparation
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int TimeUse { get; set; }

        public virtual IReadOnlyCollection<Record> Records { get; set; }
    }
}
