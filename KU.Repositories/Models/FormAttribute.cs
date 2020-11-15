using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KU.Repositories.Models
{
    public class FormAttributeWrap
    {
        public FormAttributeWrap()
        {
            result = new List<FormAttribute>();

        }
        public IEnumerable<FormAttribute> result { get; set; }



    }
    public class FormAttribute
    {
        public long FormAttributeID { get; set; }

        public long MenuID { get; set; }

        public long SectionID { get; set; }

        [StringLength(50)]
        public string AttributeName { get; set; }

        [StringLength(50)]
        public string AttributeDisplayName { get; set; }
        public bool selected { get;  set; }
    }
}
