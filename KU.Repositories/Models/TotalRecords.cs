using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KU.Repositories.Models
{

    public class TotalRecordsWrap
    {
        public TotalRecordsWrap()
        {
            result = new List<TotalRecords>();
        }
        public IEnumerable<TotalRecords> result { get; set; }

    }
    public class TotalRecords
    {
        [Key]
        public Int32  TemplateID { get; set; }
        public Int32 totalrecords { get; set; }
        public Int32 totalpages { get; set; }

        




    }
}
