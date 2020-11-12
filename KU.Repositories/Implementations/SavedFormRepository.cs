using KU.Repositories.Interfaces;
using KU.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using KU.Repositories;

namespace KU.Repositories.Implementations
{
    public class SavedFormRepository : GenericRepository<SavedForm>, ISavedFormRepository
    {

        public SavedFormRepository(DbContext context) :base(context)
        {
            
        
        }

        public IEnumerable<SavedForm> GetAllIncludedData()
        {
            return _appContext.SavedForm
                .OrderBy(c => c.MenuId)
                
                .ToList();
        }




        public IEnumerable<SavedForm> GetSavedFormByID(Int32 MenuId, Int32 SavedFormID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter)
        {

            if (string.IsNullOrEmpty(filter))
            {
                filter = "";
            }

            // if (pagenumber == 0 ) { pagenumber = 1;  }
            if (pagesize == 0) { pagesize = 10; }
            if (orderby == 0) { orderby = 1; }

            return _appContext.SavedForm.FromSql("exec sp_listform {0},{1},{2},{3},{4},{5},{6}", MenuId, SavedFormID, orderby, sortorder, pagesize, pagenumber, filter);



        }


        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
