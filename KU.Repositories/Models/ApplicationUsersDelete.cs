using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KU.Repositories.Models
{
    public class ApplicationUsersDelete
    {
        
      ///  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long UserID { get; set; }

       
        public Int32 IsActive { get; set; }
      
        public string UpdatedBy { get; set; }

      public DateTime UpdatedDate { get; set; }

        public ApplicationUsersDelete()
       {
           this.IsActive = 1;
            this.UpdatedDate = DateTime.Now;
        }
    }
}
