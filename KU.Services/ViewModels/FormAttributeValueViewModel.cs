using System;

namespace KU.Services.Interfaces
{
    public class FormAttributeValueViewModel
    {

        public long FormAttributeValueID { get; set; }
           
        public long SavedFormID { get; set; }
        public long FormAttributeID { get; set; }
        public string AttributeValue { get; set; }
    }
 
} 