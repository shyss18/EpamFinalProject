using System.Collections.Generic;

namespace EC.Entities.Entities
{
    public class Doctor : User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public User User { get; set; }

        public virtual IReadOnlyCollection<Patient> Patients { get; set; }
    }
}
