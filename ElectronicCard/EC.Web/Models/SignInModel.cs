using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EC.Web.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Введите логин")]
        [DisplayName("Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}