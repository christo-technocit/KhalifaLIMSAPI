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


        public IEnumerable<TotalRecords> GetReportTotal(long TemplateID, string SectionID, string AttributeName, string BeginPeriod, string EndPeriod, string CollectedBy, string CollectedPoint, string Nationality, string Gender, string Diabetes, string SampleID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter)
        {
           

                if (string.IsNullOrEmpty(filter))
                {
                    filter = "";
                }
                if (SectionID is null) { SectionID = "0"; }
                if (BeginPeriod is null) { BeginPeriod = "2000-01-01"; }
                if (EndPeriod is null) { EndPeriod = DateTime.Now.ToString("yyyy-MM-dd"); }
                if (CollectedBy is null) { CollectedBy = ""; }
                if (CollectedPoint is null) { CollectedPoint = ""; }
                if (Gender is null) { Gender = ""; }
                if (Diabetes is null) { Diabetes = ""; }
                if (SampleID is null) { SampleID = ""; }

                // if (pagenumber == 0) { pagenumber = 1; }
                if (pagesize == 0) { pagesize = 10; }
                if (orderby == 0) { orderby = 1; }


                // List<TotalRecords> TR = _appContext.Totalrecords.FromSql("SP_GETDATA_Total {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}", orderby, sortorder, pagesize, pagenumber, TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, filter)
                //   .ToList();
                // return TR;

                return _appContext.Totalrecords.
                  FromSql("SP_GETDATA_Total {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}", orderby, sortorder, pagesize, pagenumber, TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, filter);
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
