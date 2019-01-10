using System.Collections.Generic;
using System.Web.Mvc;

namespace EC.Entities.Entities
{
    public class Diagnosis
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual IReadOnlyCollection<SickLeave> SickLeaves { get; set; }
    }
}
