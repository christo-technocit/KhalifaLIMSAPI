using System;

namespace KU.Services.Interfaces
{
    public class SavedFormViewModel
    {

        public long SavedFormID { get; set; }

        public long MenuId { get; set; }

        public string SavedFormName { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public SavedFormViewModel()
            {
            //this.CreatedBy = '0';
            //this.UpdatedBy = 0;
            this.CreatedDate = DateTime.Now;
            //this.UpdateDate = DateTime.Now;
            }
    }
 
}