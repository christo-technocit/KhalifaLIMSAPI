﻿using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Repositories.Interfaces
{
    public interface IApplicationUsersRepository : IGenericRepository<ApplicationUsers>
    {
        IEnumerable<ApplicationUsersList> GetAllIncludedDatas(Int32 OrderBy, Int32 SortOrder, Int32 PageSize, Int32 PageNumber, string Filter);
        IEnumerable<UserGroups> GetAllUserGroups(Int32 OrderBy, Int32 SortOrder, Int32 PageSize, Int32 PageNumber, string Filter);
        //IEnumerable<ApplicationUsers> GetUser(string UserName, string Password);
        IEnumerable<ApplicationUsersList> CheckUserIDs(string UserName, string Password);
        IEnumerable<ApplicationUsers> CheckTokens(string token);


    }
}
