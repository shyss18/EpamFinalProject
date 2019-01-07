using EC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;

namespace EC.Web.Models
{
    public class CreateUserModel
    {
        [DisplayName("Логин")]
        public string Login { get; set; }

        public string Email { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }

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

        public bool IsDoctor { get; set; }

        [DisplayName("Фотография")]
        public HttpPostedFileBase Photo { get; set; }

        [DisplayName("Роль")]
        public int[] Roles { get; set; }

        [DisplayName("Номер телефона")]
        public virtual ICollection<Phone> Phones { get; set; }

        [DisplayName("Пациенты")]
        public int[] Patients { get; set; }

        [DisplayName("Врачи")]
        public int[] Doctors { get; set; }
    }
}