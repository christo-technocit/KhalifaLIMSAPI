using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KU.Repositories.Models
{
    public class SavedForm
    {
        public long SavedFormID { get; set; }

        public long MenuId { get; set; }

        [StringLength(250)]
        public string SavedFormName { get; set; }


        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }
    }


}
