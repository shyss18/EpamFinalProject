using System;

namespace EC.Entities.Entities
{
    public class Record
    {
        public int Id { get; set; }

        public DateTime DateRecord { get; set; }

        public User Patient { get; set; }

        public Diagnosis Diagnosis { get; set; }

        public Therapy Therapy { get; set; }

        public Doctor Doctor { get; set; }

        public SickLeave Type { get; set; }
    }
}
