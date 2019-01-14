using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace EC.Entities.Entities
{
    public class User
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Логин")]
        public string Login { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }

        public bool IsDoctor { get; set; }

        public virtual int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Photo Photo { get; set; }

        public virtual IReadOnlyCollection<Phone> PhoneNumbers { get; set; }

        public virtual IReadOnlyCollection<Role> Roles { get; set; }
    }
}
