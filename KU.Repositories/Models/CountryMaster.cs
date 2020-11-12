using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KU.Repositories.Models
{
    public class CountryWrap
    {
        public CountryWrap()
        {
            result = new List<CountryMaster>();

        }
        public IEnumerable<CountryMaster> result { get; set; }



    }
    public class CountryMaster
    {
        [Key]
        public long CountryID { get; set; }

        
        [StringLength(250)]
        public string CountryName { get; set; }
    }
}
