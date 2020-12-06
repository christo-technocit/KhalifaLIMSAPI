using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KU.Services.Interfaces
{
    public class UserGroupViewModel
    {
        [Key]

        public string ID { get; set; }

        public string UserGroupName { get; set; }

        public DateTime? EntryDate { get; set; }

        public Int32 Disable { get; set; }
    }
}
