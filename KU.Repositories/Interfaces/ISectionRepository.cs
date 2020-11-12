using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Repositories.Interfaces
{
    public interface ISectionRepository : IGenericRepository<Section>
    {
        IEnumerable<Section> GetAllIncludedData();
    }
}
