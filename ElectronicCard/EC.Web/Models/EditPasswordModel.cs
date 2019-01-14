using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EC.Web.Models
{
    public class EditPasswordModel
    {
        [HiddenInput]
        [DisplayName("Старый пароль")]
        public string OldPassword { get; set; }

        [DisplayName("Новый пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        [RegularExpression(@"(?=^.{6,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Пароль должен содержать символы верхнего и нижнего регистра и иметь хотя бы одну цифру")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Пароль должен иметь от 6 до 20 символов")]
        [Remote("CheckPassword", "Auth")]
        public string NewPassword { get; set; }

        [DisplayName("Подтверждение пароля")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Заполните поле")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string ComparePassword { get; set; }
    }
}