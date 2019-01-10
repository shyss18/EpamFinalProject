using System;
using System.ComponentModel.DataAnnotations;
using EC.Entities.Entities;

namespace EC.Web.Models
{
    public class EditRecordModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateRecord { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public int DiagnosisId { get; set; }

        public int SickLeaveId { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public int[] Procedures { get; set; }

        public int[] Preparations { get; set; }
    }
}