using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EC.Web.Models
{
    public class CreateRecordModel
    {
        [DisplayName("Дата записи")]
        [DataType(DataType.Date, ErrorMessage = "Поле должно быть датой")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        [Remote("CheckDate", "Record")]
        [Required(ErrorMessage = "Введите дату записи")]
        public DateTime DateRecord { get; set; }

        [Required(ErrorMessage = "Выберете пациента")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Выберете диагноз")]
        public int DiagnosisId { get; set; }

        [Required(ErrorMessage = "Выберете врача")]
        public int DoctorId { get; set; }
    
        [Required(ErrorMessage = "Выберете больничный лист")]
        public int SickLeaveId { get; set; }

        public int[] Procedures { get; set; }

        public int[] Preparations { get; set; }
    }
}