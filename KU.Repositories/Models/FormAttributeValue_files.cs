﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KU.Repositories.Models
{
    public class FormAttributeValue_files
    {
     [Key]
        public long FormAttributeValueID { get; set; }
        
        public long SavedFormID { get; set; }

        public string AttributeValue { get; set; }

    }
}
