using KU.Repositories.Interfaces;
using KU.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
        public IEnumerable<GenericResult> CheckDuplicate(Int32 MenuID, Int32 SavedFormID, string AttributeName, string AttributeValue)
        {

           return _appContext.GenericResult.FromSql("sp_CheckDuplicate {0},{1},{2},{3}", MenuID, SavedFormID, AttributeName, AttributeValue)
                .ToList();
      
        }

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
        public IEnumerable<GenericResult> GetRecords(Int32 MenuID, Int32 SavedFormID,Int32 SectionID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter, string CompanyName, string FromDate, string ToDate)
        {
            if (pagesize == 0)
                pagesize = 10;

            if (SavedFormID == 0)
            {
                return _appContext.GenericResult.FromSql("sp_getrecordPage {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", MenuID, SectionID, 0,  orderby,  sortorder,  pagesize,  pagenumber,  filter,  CompanyName,  FromDate,  ToDate).ToList();
            }
            else
            {
                return _appContext.GenericResult.FromSql("sp_getrecordPage {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", MenuID, SectionID, SavedFormID,  orderby,  sortorder,  pagesize,  pagenumber,  filter,  CompanyName,  FromDate,  ToDate).ToList();
            }
        }

        // For Reports Begin
        public IEnumerable<GenericResult> GetReportCommon(int orderby, int sortorder, int pagesize, int pagenumber, string MenuID, string SectionID, string AttributeName,  string SampleCollectionDateFrom, string SampleCollectionDateTo, string ReceivingDateFrom, string ReceivingDateTo, string KUReference, string Location, string StationCode, string CompanyName, string SampleType, string SampleSubType, string SampleCollectionType, string CollectedBy, string Emirate, string SampleID, string Filter)
        {
            if (string.IsNullOrEmpty(Filter))
            {
                Filter = "";
            }

      
            if (SampleCollectionDateFrom is null) { SampleCollectionDateFrom = "2000-01-01"; }
            if (SampleCollectionDateTo is null) { SampleCollectionDateTo = DateTime.Now.ToString("yyyy-MM-dd"); }

            if (ReceivingDateFrom is null) { ReceivingDateFrom = "2000-01-01"; }
            if (ReceivingDateTo is null) { ReceivingDateTo = DateTime.Now.ToString("yyyy-MM-dd"); }

            if (pagesize == 0) { pagesize = 10; }
            if (orderby == 0) { orderby = 1; }


            List<GenericResult> TR = _appContext.GenericResult.FromSql("SP_GETDATANew {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", orderby, sortorder, pagesize, pagenumber, MenuID, SectionID, AttributeName, SampleCollectionDateFrom, SampleCollectionDateTo, ReceivingDateFrom, ReceivingDateTo, KUReference, Location, StationCode, CompanyName, SampleType, SampleSubType, SampleCollectionType, CollectedBy, Emirate, SampleID, Filter)
              .ToList();
            return TR;

        }

        public IEnumerable<GenericResult> GetStat(string FromDate, string ToDate, string Company, string Location, string Station, int ReportType)
        {
            List<GenericResult> TR = _appContext.GenericResult.FromSql("SP_Statistics_Report {0},{1},{2},{3},{4},{5}", FromDate, ToDate, Company, Location, Station, ReportType)
              .ToList();
            return TR;

        }




        public IEnumerable<GenericResult> ImportSample(List<SampleForm> Model,string UserName)
            
        {
   
            string Result = JsonConvert.SerializeObject(Model);


           // var all = _appContext.GenericResult.FromSql("Sp_importSample {0},{1}", Result, UserName);
            return _appContext.GenericResult.FromSql("Sp_importSample {0},{1}", Result, UserName).ToList();

        }


        //For Reports end
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
