using System.Collections.Generic;

namespace EC.Entities.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IReadOnlyCollection<User> Users { get; set; }
    }
}
