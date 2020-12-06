using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KU.Services.Interfaces
{
    public class ApplicationUsersDeleteViewModel
    {


        ///  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long UserID { get; set; }


        public Int32 IsActive { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public ApplicationUsersDeleteViewModel()
        {
            this.IsActive = 1;
            this.UpdatedDate = DateTime.Now;
        }
    }
 
}