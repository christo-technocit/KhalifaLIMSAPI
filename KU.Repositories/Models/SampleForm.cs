using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KU.Repositories.Models
{
    public class SampleForm
    {
        public string LOCATION { get; set; }
        public string SAMPLINGDATE { get; set; }
        public string KUREFERENCE { get; set; }
        public string STATIONCODE { get; set; }
        public string INFLUENTFLOWRATE { get; set; }
        public string USERNAME { get; set; }
        public string COMPANYNAME { get; set; }
    }
}
