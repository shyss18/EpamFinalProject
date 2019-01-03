using System.Collections.Generic;

namespace EC.Entities.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsDoctor { get; set; }

        public virtual int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual int PhotoId { get; set; }

        public virtual Photo Photo { get; set; }

        public virtual IReadOnlyCollection<Phone> PhoneNumbers { get; set; }

        public virtual IReadOnlyCollection<Role> Roles { get; set; }

        public virtual IReadOnlyCollection<Record> Records { get; set; }
    }
}
