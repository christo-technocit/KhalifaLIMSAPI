using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KU.Repositories.Models
{

    public class GenericResultWrap
    {
        public GenericResultWrap()
        {
            result = new List<GenericResult>();
        }
        public IEnumerable<GenericResult> result { get; set; }

    }
    public class GenericResult
    {
        [Key]
        public string  Items { get; set; }

    }
}
