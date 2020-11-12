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
    public class GenericResultRepository : GenericRepository<GenericResult>, IGenericResultRepository
    {
        public GenericResultRepository(DbContext context) : base(context)
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

        public IEnumerable<GenericResult> GetMenu(string UserName)
        {

           return _appContext.GenericResult.FromSql("SP_GetMenu {0}", UserName) .ToList();
        }

        // for menu template
        public IEnumerable<GenericResult> GetTemplate(string UserName)
        {

            return _appContext.GenericResult.FromSql("SP_GetTemplate {0}", UserName).ToList();
        }
        // for reports template
        public IEnumerable<GenericResult> GetReportTemplate(string UserName)
        {

            return _appContext.GenericResult.FromSql("SP_Report_Templates {0}", UserName).ToList();
        }


        // For Get Records
        public IEnumerable<GenericResult> GetRecords(Int32 TemplateID, Int32 SavedFormID,Int32 SectionID )
        {
            if (SavedFormID == 0)
            {
                return _appContext.GenericResult.FromSql("sp_getrecordsNew {0},{1}", TemplateID, SectionID).ToList();
            }
            else
            {
                return _appContext.GenericResult.FromSql("sp_getrecordsNew {0},{1},{2}", TemplateID, SectionID, SavedFormID).ToList();
            }
        }

        // For Reports Begin
        public IEnumerable<GenericResult> GetReportCommon(long TemplateID, long SectionID, string AttributeName, string BeginPeriod, string EndPeriod, string CollectedBy, string CollectedPoint, string Nationality, string Gender, string Diabetes, string SampleID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                filter = "";
            }

            if (SectionID.ToString() is null) { SectionID = 0; }
            if (BeginPeriod is null) { BeginPeriod = "2000-01-01"; }
            if (EndPeriod is null) { EndPeriod = DateTime.Now.ToString("yyyy-MM-dd"); }
            if (CollectedBy is null) { CollectedBy = ""; }
            if (CollectedPoint is null) { CollectedPoint = ""; }
            if (Gender is null) { Gender = ""; }
            if (Diabetes is null) { Diabetes = ""; }
            if (SampleID is null) { SampleID = ""; }

            //   if (pagenumber == 0) { pagenumber = 1; }
            if (pagesize == 0) { pagesize = 10; }
            if (orderby == 0) { orderby = 1; }


            List<GenericResult> TR = _appContext.GenericResult.FromSql("SP_GETDATANew {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}", orderby, sortorder, pagesize, pagenumber, TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, filter)
              .ToList();
            return TR;

        }

        //For Reports end
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
