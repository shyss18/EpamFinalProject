using System.Web.Mvc;

namespace EC.Entities.Entities
{
    public class Phone
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
