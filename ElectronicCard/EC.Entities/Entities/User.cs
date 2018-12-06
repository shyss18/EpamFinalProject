using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace EC.Entities.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public DateTime DateBirth { get; set; }

        public IReadOnlyCollection<Phone> PhoneNumbers { get; set; }

        public string PlaceWork { get; set; }

        public Url Photo { get; set; }

        public IReadOnlyCollection<Role> Roles { get; set; }
    }
}
