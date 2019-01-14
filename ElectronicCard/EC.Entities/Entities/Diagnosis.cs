using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EC.Entities.Entities
{
    public class Diagnosis
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Название диагноза")]
        [Required(ErrorMessage = "Введите название диагноза")]
        [StringLength(150, ErrorMessage = "Название диагноза должно быть до 20 знаков")]
        public string Title { get; set; }
    }
}
