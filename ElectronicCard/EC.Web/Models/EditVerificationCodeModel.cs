using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EC.Web.Models
{
    public class EditVerificationCodeModel
    {
        [HiddenInput]
        [DisplayName("Старый код")]
        public string OldCode { get; set; }

        [DisplayName("Новый код")]
        [Required(ErrorMessage = "Введите код")]
        [StringLength(6, ErrorMessage = "Максимальная длина кода 6 знаков")]
        public string NewCode { get; set; }
    }
}