using System;
using System.Collections.Generic;

namespace EC.Entities.Entities
{
    public class Patient : User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PlaceWork { get; set; }

        public DateTime DateBirth { get; set; }

        public User User { get; set; }

        public virtual IReadOnlyCollection<Doctor> Doctors { get; set; }
    }
}
