using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Repositories.Interfaces
{
    public interface IFormAttributeValueRepository : IGenericRepository<FormAttributeValue>
    {
        IEnumerable<FormAttributeValue> GetAllIncludedData();
        IEnumerable<FormAttributeValue> GetFormByID(Int32 savedFormID);
        IEnumerable<FormAttributeValue> MoveImage(long SavedFormID, long FormAttributeID);
    }
}