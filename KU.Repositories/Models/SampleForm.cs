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

        public string SAMPLETYPE { get; set; }
        public string SAMPLESUBTYPE { get; set; }
        public string SAMPLEVOLUME { get; set; }
        public string SAMPLECOLLECTIONTYPE { get; set; }
        public string STARTDATECOLLECTION { get; set; }
        public string STARTTIMECOLLECTION { get; set; }
        public string ENDDATECOLLECTION { get; set; }
        public string ENDTIMECOLLECTION { get; set; }
        public string COLLECTEDBY { get; set; }
        public string EMIRATE { get; set; }
        public string TEMPERATURE { get; set; }
        public string  CONDUCTIVITY { get; set; }
        public string DISSOLVEDOXYGEN { get; set; }
        public string PH { get; set; }
        public string POPULATIONESTIMATESERVEDBYSTATION { get; set; }
        public string NUMBEROFINFECTEDPEOPLE { get; set; }
        public string RNAVIRALCOUNTS { get; set; }
        public string STANDARDDEVIATION { get; set; }

    }
}
