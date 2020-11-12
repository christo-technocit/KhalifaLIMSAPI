using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Repositories.Interfaces
{
    public interface ITotalRecordsRepository : IGenericRepository<TotalRecords>
    {
        
      // TotalRecords_Wrap GetTotal(Int32 TemplateID, Int32 PageSize, string SearchStr);
           IEnumerable<TotalRecords> GetTotal(Int32 TemplateID, Int32 PageSize, string SearchStr);

        
    }
}
