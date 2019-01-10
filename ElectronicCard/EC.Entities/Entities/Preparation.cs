using System.Collections.Generic;
using System.Web.Mvc;

namespace EC.Entities.Entities
{
    public class Preparation
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int TimeUse { get; set; }

        public virtual IReadOnlyCollection<Record> Records { get; set; }
    }
}
