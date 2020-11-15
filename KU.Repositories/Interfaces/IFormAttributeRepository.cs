using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Repositories.Interfaces
{
    public interface IFormAttributeRepository : IGenericRepository<FormAttribute>
    {
        IEnumerable<FormAttribute> GetAllIncludedData();
        IEnumerable<FormAttribute> GetAttributeName(Int32 Menuid, Int32 savedFormID);

        IEnumerable<FormAttribute> GetAttributeID(string Menuid, string SectionID, string AttributeName);
        IEnumerable<FormAttribute> GetAttributeIDReports(string Menuid, string SectionID, string AttributeName);
    }
}
