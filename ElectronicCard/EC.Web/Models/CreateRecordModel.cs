using System;
using System.ComponentModel.DataAnnotations;

namespace EC.Web.Models
{
    public class CreateRecordModel
    {
        [DataType(DataType.Date)]
        public DateTime DateRecord { get; set; }

        public int PatientId { get; set; }

        public int DiagnosisId { get; set; }

        public int DoctorId { get; set; }
    
        public int SickLeaveId { get; set; }

        public int[] Procedures { get; set; }

        public int[] Preparations { get; set; }
    }
}