using System.Collections.Generic;

namespace EC.Entities.Entities
{
    public class SerializeModel
    {
        public string Login { get; set; }

        public IReadOnlyCollection<Role> Roles { get; set; }
    }
}
