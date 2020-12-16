using KU.Repositories.Interfaces;
using KU.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace KU.Repositories.Implementations
{
    public class QuestionnaireRepository : GenericRepository<QuestionnaireRepository>, IQuestionnaireRepository
    {
        public QuestionnaireRepository(DbContext context) : base(context)
        { }


        public IEnumerable<TotalRecords> GetReportTotal(long MenuID, string SectionID, string AttributeName, string SampleCollectionDateFrom, string SampleCollectionDateTo, string ReceivingDateFrom, string ReceivingDateTo, string KUReference, string Location, string StationCode, string CompanyName, string SampleType, string SampleSubType, string SampleCollectionType, string CollectedBy, string Emirate, string SampleID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter)
        {
                if (string.IsNullOrEmpty(filter))
                {
                    filter = "";
                }
                if (SectionID is null) { SectionID = "0"; }
                if (SampleCollectionDateFrom is null) { SampleCollectionDateFrom = "2000-01-01"; }
                if (SampleCollectionDateTo is null) { SampleCollectionDateTo = DateTime.Now.ToString("yyyy-MM-dd"); }
            if (ReceivingDateFrom is null) { ReceivingDateFrom = "2000-01-01"; }
            if (ReceivingDateTo is null) { ReceivingDateTo = DateTime.Now.ToString("yyyy-MM-dd"); }
            if (CollectedBy is null) { CollectedBy = ""; }
                if (KUReference is null) { KUReference = ""; }
                if (Location is null) { Location = ""; }
                if (StationCode is null) {StationCode = ""; }
            if (CompanyName is null) { CompanyName = ""; }
            if (SampleType is null) { SampleType = ""; }
            if (SampleSubType is null) { SampleSubType = ""; }
            if (SampleCollectionType is null) { SampleCollectionType = ""; }
            if (Emirate is null) { Emirate = ""; }
            if (SampleID is null) { SampleID = ""; }
            if (AttributeName is null) { AttributeName = ""; }
            // if (pagenumber == 0) { pagenumber = 1; }
            if (pagesize == 0) { pagesize = 10; }
                if (orderby == 0) { orderby = 1; }


                // List<TotalRecords> TR = _appContext.Totalrecords.FromSql("SP_GETDATA_Total {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}", orderby, sortorder, pagesize, pagenumber, TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, filter)
                //   .ToList();
                // return TR;

                return _appContext.Totalrecords.
                  FromSql("SP_GETREPORTDATA_Total {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", orderby, sortorder, pagesize, pagenumber, MenuID, SectionID, AttributeName, SampleCollectionDateFrom, SampleCollectionDateTo, ReceivingDateFrom, ReceivingDateTo, KUReference, Location, StationCode, CompanyName,  SampleType,  SampleSubType,  SampleCollectionType, CollectedBy, Emirate, SampleID, filter).ToList();
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
