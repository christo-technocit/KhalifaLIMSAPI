using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KU.Repositories.Models
{
     public class ViralLoadChartData
    {
  //      public string SampleCollectionDate { get; set; }
        [Key]
        public string location { get; set; }
        public double viralcountsperdaylocation { get; set; }
        public double standarddeviationviralgenomes { get; set; }

    //    public IEnumerable<ViralLoadChartData> result { get; set; }

    }
   
//public class ViralLoadChartData
//{
  //  [Key]
  //  public string Items { get; set; }

//}
}
