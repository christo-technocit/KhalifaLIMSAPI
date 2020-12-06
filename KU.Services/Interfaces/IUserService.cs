using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Services.Interfaces

{
    public interface IUserService
    {
        // user module begin
        IEnumerable<GenericResult> GetMenu(string UserName);
        IEnumerable<GenericResult> GetTemplate(string UserName);
        IEnumerable<GenericResult> GetReportTemplate(string UserName);
        IEnumerable<ApplicationUser> GetAllIncludedData(Int32 OrderBy, Int32 SortOrder, Int32 PageSize, Int32 PageNumber, string Filter);
        // IEnumerable<ApplicationUsers> GetUser(string UserName, string Password);

        IEnumerable<ApplicationUsersList> GetAllIncludedDatas(Int32 OrderBy, Int32 SortOrder, Int32 PageSize, Int32 PageNumber, string Filter);
        IEnumerable<UserGroups> GetAllUserGroups(Int32 OrderBy, Int32 SortOrder, Int32 PageSize, Int32 PageNumber, string Filter);
        IEnumerable<ApplicationUsersList> CheckUserIDs(string UserName, string Password);
        IEnumerable<ApplicationUsers> CheckTokens(string token);

        long InsertUser(ApplicationUsersViewModel model);
        long UpdateUser(ApplicationUsersViewModel model);
        long DeleteUser(ApplicationUsersViewModel model);

        // user module end




    }
}
