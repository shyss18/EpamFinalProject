using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace EC.Web.Models
{
    public class CreateUserModel
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
        [Required(ErrorMessage = "Введите место работы")]
        public string PlaceWork { get; set; } = "Default";

        [DisplayName("Должность")]
        [Required(ErrorMessage = "Введите должность")]
        public string Position { get; set; } = "Default";

        [DisplayName("Дата рождения")]
        [DataType(DataType.Date, ErrorMessage = "Поле должно быть датой")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        [Remote("CheckDate", "User")]
        [Required(ErrorMessage = "Введите дату рождения")]
        public DateTime DateBirth { get; set; } = DateTime.Now;

        public bool IsDoctor { get; set; }

        [DisplayName("Фотография")]
        public HttpPostedFileBase Photo { get; set; }

        [DisplayName("Роль")]
        [Required(ErrorMessage = "Выберете роли")]
        public int[] Roles { get; set; }

        [DisplayName("Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Введите номер телефона")]
        [RegularExpression(@"[\(]\d{4}[\)][\-]\d{3}[\-]\d{2}[\-]\d{2}", ErrorMessage = "Формат телефона (код оператора)-xxx-xx-xx")]
        public string Phone { get; set; }

        [DisplayName("Пациенты")]
        public int[] Patients { get; set; }

        [DisplayName("Врачи")]
        public int[] Doctors { get; set; }
    }
}