using EC.Entities.Entities;
using System.Web;

namespace EC.Web.Models
{
    public class EditPhotoModel
    {
        public int Id { get; set; }

        public Photo UserPhoto { get; set; }

        public int UserId { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}