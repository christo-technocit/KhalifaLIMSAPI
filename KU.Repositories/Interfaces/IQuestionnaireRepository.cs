using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Repositories.Interfaces
{
    public interface IQuestionnaireRepository 
    {
        


        IEnumerable<TotalRecords> GetReportTotal(long MenuID, string SectionID, string AttributeName, string SampleCollectionDateFrom, string SampleCollectionDateTo, string ReceivingDateFrom, string ReceivingDateTo, string KUReference, string Location, string StationCode, string CompanyName, string SampleType, string SampleSubType, string SampleCollectionType, string CollectedBy, string Emirate, string SampleID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter);
 
    }
}

