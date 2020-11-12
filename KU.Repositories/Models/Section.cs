using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KU.Repositories.Models
{
    public class Section
    {
        public long SectionID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Icon { get; set; }

        [StringLength(250)]
        public string CSS { get; set; }
    }
}
