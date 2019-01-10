using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EC.Entities.Entities
{
    public class Procedure
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Название процедуры")]
        [Required(ErrorMessage = "Введите название процедуры")]
        [StringLength(20, ErrorMessage = "Длина названия процедуры должна быть до 20 знаков")]
        public string Title { get; set; }

        [DisplayName("Описание")]
        [Required(ErrorMessage = "Введите описание процедуры")]
        [StringLength(150, ErrorMessage = "Описание процедуры должно быть до 150 знаков")]
        public string Description { get; set; }

        [DisplayName("Продолжительность лечения")]
        [Required(ErrorMessage = "Введите продолжительность лечения")]
        public int TimeUse { get; set; }
    }
}
