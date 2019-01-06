using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EC.Entities.Entities
{
    public class Patient : User
    {
        public int UserId { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Отчество")]
        public string MiddleName { get; set; }

        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [DisplayName("Место работы")]
        public string PlaceWork { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Дата рождения")]
        public DateTime DateBirth { get; set; }

        public User User { get; set; }

        public virtual IReadOnlyCollection<Doctor> Doctors { get; set; }
    }
}
