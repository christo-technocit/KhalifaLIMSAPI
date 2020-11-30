using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KU.Repositories.Models
{
    public class ApplicationUsersList
    {
        
      ///  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      [Key]
        public long UserID { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }

      
    }
}
