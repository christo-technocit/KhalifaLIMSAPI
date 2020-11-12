using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Repositories.Interfaces
{
    public interface ISavedFormRepository : IGenericRepository<SavedForm>
    {
        IEnumerable<SavedForm> GetAllIncludedData();
        IEnumerable<SavedForm> GetSavedFormByID(Int32 MenuId, Int32 savedFormID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter);
    



    }
}
