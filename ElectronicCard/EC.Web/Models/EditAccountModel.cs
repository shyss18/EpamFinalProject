using System;
using System.ComponentModel;
using System.Web.Mvc;

namespace EC.Web.Models
{
    public class EditAccountModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Логин")]
        public string Login { get; set; }

        public string Email { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Отчество")]
        public string MiddleName { get; set; }

        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [DisplayName("Место работы")]
        public string PlaceWork { get; set; }

        [DisplayName("Должность")]
        public string Position { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime DateBirth { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool IsDoctor { get; set; }
    }
}