using KU.Repositories.Interfaces;
using KU.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace KU.Repositories.Implementations
{
    public class ApplicationUsersRepository : GenericRepository<ApplicationUsers>, IApplicationUsersRepository
    {
        public ApplicationUsersRepository(DbContext context) : base(context)
        { }

        public IEnumerable<ApplicationUsers> GetAllIncludedDatas(Int32 OrderBy, Int32 SortOrder, Int32 PageSize, Int32 PageNumber, string Filter)
        {
            //@orderby int=1,  --1= ID,  2 =Username, 3 = Email, 4 = FullName, 5 = Roles
            //@sortorder int = 0, --0 asc - 1 desc
            //   @pagesize int= 10,
            //   @pagenumber int = 0,
            //   @filter varchar(max) = ''
            if (string.IsNullOrEmpty(Filter))
            {
                Filter = "";
            }

           // if (PageNumber == 0) { PageNumber = 1; }
            if (PageSize == 0) { PageSize = 10; }
            if (OrderBy == 0) { OrderBy = 1; }
            if (SortOrder == 0) { SortOrder = 1; }

            return _appContext.ApplicationUsers.FromSql("sp_get_userID {0},{1},{2},{3},{4}",OrderBy, SortOrder,PageSize,PageNumber,Filter)
                .ToList();
        }

        public IEnumerable<ApplicationUsers> CheckUserIDs(string UserName, string Password)
        {
            return _appContext.ApplicationUsers.FromSql("sp_check_UserID {0},{1}", UserName, Password)
                .OrderBy(C => C.UserId)
                .ToList();
        }

        public IEnumerable<ApplicationUsers> CheckTokens(string Token)
        {
            return _appContext.ApplicationUsers.FromSql("Sp_Check_TokenID {0}", Token)
                .ToList();
        }

   
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

     

    }
}
