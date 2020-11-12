using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KU.Repositories.Models
{
    public class Template
    {
        public long TemplateID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string URL { get; set; }

        [StringLength(250)]
        public string CSS { get; set; }

        public string root { get; set; }
        public string icon { get; set; }
        public string bullet { get; set; }
        public string Link { get; set; }


    }
}
