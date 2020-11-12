using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Repositories.Interfaces
{
    public interface IQuestionnaireRepository 
    {
        


        IEnumerable<TotalRecords> GetReportTotal(long TemplateID, string SectionID, string AttributeName, string BeginPeriod, string EndPeriod, string CollectedBy, string CollectedPoint, string Nationality, string Gender, string Diabetes, string SampleID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter);
 
    }
}

