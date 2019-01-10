using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EC.Web.Models
{
    public class EditSickLeaveModel
    {
        public int Id { get; set; }

        public bool IsGive { get; set; }

        [DisplayName("Номер")]
        [Required(ErrorMessage = "Введите номер")]
        public int Number { get; set; }

        [DisplayName("Период действия")]
        [Required(ErrorMessage = "Введите период действия")]
        public int PeriodAction { get; set; }

        [Required(ErrorMessage = "Выберете диагноз")]
        public int DiagnosisId { get; set; }
    }
}