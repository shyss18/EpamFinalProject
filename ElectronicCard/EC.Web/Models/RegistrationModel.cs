using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace EC.Web.Models
{
    public class RegistrationModel
    {
        [DisplayName("Логин")]
        [Required(ErrorMessage = "Введите логин")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Длина логина должна быть от 5 до 50 символов")]
        [Remote("CheckLogin", "Auth")]
        public string Login { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Введите email")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Длина email должна быть от 5 до 50 символов")]
        [Remote("CheckEmail", "Auth")]
        public string Email { get; set; }

        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        [RegularExpression(@"(?=^.{6,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Пароль должен содержать символы верхнего и нижнего регистра и иметь хотя бы одну цифру")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Пароль должен иметь от 6 до 20 символов")]
        public string Password { get; set; }

        [DisplayName("Подтверждение пароля")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Заполните поле")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        public bool IsDoctor { get; set; }

        [DisplayName("Фотография")]
        public HttpPostedFileBase Photo { get; set; }

        [DisplayName("Имя")]
        [Required(ErrorMessage = "Введите имя")]
        public string FirstName { get; set; }

        [DisplayName("Отчество")]
        [Required(ErrorMessage = "Введите отчество")]
        public string MiddleName { get; set; }

        [DisplayName("Фамилия")]
        [Required(ErrorMessage = "Введите фамилию")]
        public string LastName { get; set; }

        [DisplayName("Место работы")]
        public string PlaceWork { get; set; }

        [DisplayName("Должность")]
        public string Position { get; set; }

        [DisplayName("Дата рождения")]
        [DataType(DataType.Date, ErrorMessage = "Поле должно быть датой")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        [Remote("CheckDate", "User")]
        public DateTime DateBirth { get; set; }

        [DisplayName("Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Введите номер телефона")]
        [RegularExpression(@"[\(]\d{4}[\)][\-]\d{3}[\-]\d{2}[\-]\d{2}", ErrorMessage = "Формат телефона (код оператора)-xxx-xx-xx")]
        public string Phone { get; set; }
    }
}