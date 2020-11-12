using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Repositories.Interfaces
{
    public interface IFormAttributeRepository : IGenericRepository<FormAttribute>
    {
        IEnumerable<FormAttribute> GetAllIncludedData();
        IEnumerable<FormAttribute> GetAttributeName(Int32 TemplateID, Int32 savedFormID);

        IEnumerable<FormAttribute> GetAttributeID(string TemplateID, string SectionID, string AttributeName);
        IEnumerable<FormAttribute> GetAttributeIDReports(string TemplateID, string SectionID, string AttributeName);
    }
}
