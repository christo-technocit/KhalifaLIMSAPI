﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KU.Repositories.Models
{
    public class ApplicationUsers
    {
        [Key]
      ///  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserId { get; set; }

        public string UserName { get; set; }

       // public string Password { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

      //  public string Occupation { get; set; }
        public string CompanyName { get; set; } 
      //  public string PhoneNumber { get; set; }
      //  public string Address { get; set; }
      //  public string City { get; set; }
      //  public string State { get; set; }
      //  public string PostalCode { get; set; }
      //  public string linkedin { get; set; }
      //  public string facebook { get; set; }
      //  public string twitter { get; set; }
      //  public string Instagram { get; set; }
      //  public string SecurityStamp { get; set; }
      //  public Int32 IsActive { get; set; }
      // public string CreatedBy { get; set; }
      //  public string UpdatedBy { get; set; }
      //  public DateTime? CreatedDate { get; set; }
      //public DateTime? UpdatedDate { get; set; }

        //public ApplicationUsers()
        //{
        
        //    this.Password = "";
        //    this.IsActive = 1;
        //    this.CreatedDate = DateTime.Now ; 
        //    this.UpdatedDate = DateTime.Now;
        //}
    }
}
