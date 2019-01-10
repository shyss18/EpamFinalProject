using System.Web.Mvc;

namespace EC.Web.Models
{
    public class EditPasswordModel
    {
        [HiddenInput]
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ComparePassword { get; set; }
    }
}