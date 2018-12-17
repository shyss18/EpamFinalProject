using System.Security.Policy;

namespace EC.Entities.Entities
{
    public class Promotion
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public Url Photo { get; set; }
    }
}
