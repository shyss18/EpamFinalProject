using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EC.Entities.Entities
{
    public class Preparation
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Название препарата")]
        [Required(ErrorMessage = "Введите название препарата")]
        [StringLength(20, ErrorMessage = "Длина названия препарата должна быть до 20 знаков")]
        public string Title { get; set; }

        [DisplayName("Описание препарата")]
        [Required(ErrorMessage = "Введите описание препарата")]
        [StringLength(150, ErrorMessage = "Описание препарата должно быть до 150 знаков")]
        public string Description { get; set; }

        [DisplayName("Продолжительность применения")]
        [Required(ErrorMessage = "Введите продолжительность применения")]
        public int TimeUse { get; set; }
    }
}
