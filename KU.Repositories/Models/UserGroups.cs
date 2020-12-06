using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KU.Repositories.Models
{
    public class UserGroups
    {
        [Key]
      ///  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }

        public string UserGroupName { get; set; }

       // public string Password { get; set; }

    

        //public ApplicationUsers()
        //{
        
        //    this.Password = "";
        //    this.IsActive = 1;
        //    this.CreatedDate = DateTime.Now ; 
        //    this.UpdatedDate = DateTime.Now;
        //}
    }
}
