using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Repositories.Interfaces
{
    public interface IFormAttributeValue_filesRepository : IGenericRepository<FormAttributeValue_files>
    {
        IEnumerable<FormAttributeValue_files> GetDocumentByID(Int32 savedFormID);
        // IEnumerable<FormAttributeValue_files> UploadDocument(long FormAttributeValueID, long SavedFormID,  string FormAttributeValue);
    }
}