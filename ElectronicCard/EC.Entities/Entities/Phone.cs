using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EC.Entities.Entities
{
    public class Phone
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Введите номер телефона")]
        [RegularExpression(@"[\(]\d{4}[\)][\-]\d{3}[\-]\d{2}[\-]\d{2}", ErrorMessage = "Формат телефона (код оператора)-xxx-xx-xx")]
        [Remote("CheckPhone", "Phone")]
        public string PhoneNumber { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
