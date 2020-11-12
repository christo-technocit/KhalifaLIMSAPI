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
    public class TotalRecordsRepository : GenericRepository<TotalRecords>, ITotalRecordsRepository
    {
        public TotalRecordsRepository(DbContext context) : base(context)
        { }

        // to show which result head
        //public IEnumerable<TotalRecords> GetTotal(Int32 TemplateID, Int32 PageSize, string SearchStr)
        
        //{
        //    if (PageSize == 0)
        //    {
        //        PageSize = 10;
        //    }

        //    if (string.IsNullOrEmpty(SearchStr))
        //        { SearchStr = ""; }


        //    //List<TotalRecords> TR =

        //    List<TotalRecords> TR =  _appContext.Totalrecords.FromSql("sp_gettotal {0},{1},{2}", TemplateID, PageSize, SearchStr)
        //        .ToList();
        //    return TR;

        //       // return  new TotalRecords_Wrap { result = TR };



        //}

        public IEnumerable<TotalRecords> GetTotal(Int32 TemplateID, Int32 PageSize, string SearchStr)
        {
            if (PageSize == 0)
            {
                PageSize = 10;
            }

            if (string.IsNullOrEmpty(SearchStr))
            { SearchStr = ""; }

            return _appContext.Totalrecords.FromSql("sp_gettotal {0},{1},{2}", TemplateID, PageSize, SearchStr)
                .ToList();
        }


        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
