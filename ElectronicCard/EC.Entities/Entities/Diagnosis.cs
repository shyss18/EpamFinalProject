using System.Collections.Generic;

namespace EC.Entities.Entities
{
    public class Diagnosis
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual IReadOnlyCollection<SickLeave> SickLeaves { get; set; }
    }
}
