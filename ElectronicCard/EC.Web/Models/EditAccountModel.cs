using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EC.Web.Models
{
    public class EditAccountModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

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

        [HiddenInput(DisplayValue = false)]
        public bool IsDoctor { get; set; }
    }
}