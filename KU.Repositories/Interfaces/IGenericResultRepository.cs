using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KU.Repositories.Interfaces
{
    public interface IGenericResultRepository : IGenericRepository<GenericResult>
    {
        
      // TotalRecords_Wrap GetTotal(Int32 TemplateID, Int32 PageSize, string SearchStr);
        IEnumerable<GenericResult> GetMenu (string UserName);
        IEnumerable<GenericResult> GetTemplate(string UserName);
        IEnumerable<GenericResult> GetReportTemplate(string UserName);
        // Get Records
        IEnumerable<GenericResult> GetRecords(Int32 MenuID, Int32 SavedFormID, Int32 SectionID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter, string CompanyName, string FromDate, string ToDate);
        // For Reports
        IEnumerable<GenericResult> GetReportCommon(int orderby, int sortorder, int pagesize, int pagenumber, string MenuID, string SectionID, string AttributeName, string SampleCollectionDateFrom, string SampleCollectionDateTo, string ReceivingDateFrom, string ReceivingDateTo, string KUReference, string Location, string StationCode, string CompanyName, string SampleType, string SampleSubType, string SampleCollectionType, string CollectedBy, string Emirate, string SampleID, string Filter);

        IEnumerable<GenericResult> ImportSample(List<SampleForm> Model,string UserName);

        IEnumerable<GenericResult> CheckDuplicate(Int32 MenuID, Int32 SavedFormID, string AttributeName, string AttributeValue);
    }
}
