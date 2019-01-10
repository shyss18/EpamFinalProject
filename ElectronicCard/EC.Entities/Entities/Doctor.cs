using System.Collections.Generic;
using System.ComponentModel;

namespace EC.Entities.Entities
{
    public class Doctor : User
    {
        public int UserId { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Отчество")]
        public string MiddleName { get; set; }

        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [DisplayName("Должность")]
        public string Position { get; set; }

        public User User { get; set; }

        public virtual IReadOnlyCollection<Patient> Patients { get; set; }
    }
}
