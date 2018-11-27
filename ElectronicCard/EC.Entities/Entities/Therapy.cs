using System.Collections.Generic;

namespace EC.Entities.Entities
{
    public class Therapy
    {
        public int Id { get; set; }

        public IReadOnlyCollection<Preparation> Preparations{ get; set; }

        public IReadOnlyCollection<Procedure> Procedures { get; set; }
    }
}
