using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Repositories.Interfaces
{
    public interface IGenericResultRepository : IGenericRepository<GenericResult>
    {
        
      // TotalRecords_Wrap GetTotal(Int32 TemplateID, Int32 PageSize, string SearchStr);
           IEnumerable<GenericResult> GetMenu (string UserName);
        IEnumerable<GenericResult> GetTemplate(string UserName);
        IEnumerable<GenericResult> GetReportTemplate(string UserName);
        // Get Records
        IEnumerable<GenericResult> GetRecords(Int32 TemplateID, Int32 SavedFormID, Int32 SectionID );
        // For Reports
        IEnumerable<GenericResult> GetReportCommon(long TemplateID, long SectionID, string AttributeName, string BeginPeriod, string EndPeriod, string CollectedBy, string CollectedPoint, string Nationality, string Gender, string Diabetes, string SampleID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter);


    }
}
