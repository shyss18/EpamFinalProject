using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EC.Web.Models
{
    public class EditUserModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }


        [DisplayName("Имя")]
        [Required(ErrorMessage = "Введите имя")]
        public string FirstName { get; set; }

        [DisplayName("Отчество")]
        [Required(ErrorMessage = "Введите отчество")]
        public string MiddleName { get; set; }

        [DisplayName("Фамилия")]
        [Required(ErrorMessage = "Введите фамилию")]
        public string LastName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool IsDoctor { get; set; }

        [DisplayName("Должность")]
        public string Position { get; set; }

        [DisplayName("Место работы")]
        public string PlaceWork { get; set; }

        [DisplayName("Дата рождения")]
        [DataType(DataType.Date, ErrorMessage = "Поле должно быть датой")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        [Remote("CheckDate", "User")]
        public DateTime DateBirth { get; set; }

        [DisplayName("Роли")]
        [Required(ErrorMessage = "Выбере роли")]
        public int[] Roles { get; set; }

        [DisplayName("Пациенты")]
        public int[] Patients { get; set; }

        [DisplayName("Доктора")]
        public int[] Doctors { get; set; }
    }
}