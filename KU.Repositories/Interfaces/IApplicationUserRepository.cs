using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Repositories.Interfaces
{
    public interface IApplicationUserRepository : IGenericRepository<ApplicationUser>
    {
        IEnumerable<ApplicationUser> GetAllIncludedData(Int32 OrderBy, Int32 SortOrder, Int32 PageSize, Int32 PageNumber, string Filter);
       //IEnumerable<ApplicationUsers> GetUser(string UserName, string Password);
      

    }
}
