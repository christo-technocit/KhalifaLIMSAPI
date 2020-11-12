using KU.Repositories.Interfaces;
using KU.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace KU.Repositories.Implementations
{
    public class SectionRepository : GenericRepository<Section>, ISectionRepository
    {
        public SectionRepository(DbContext context) : base(context)
        { }

        public IEnumerable<Section> GetAllIncludedData()
        {
            return _appContext.Sections
                .OrderBy(c => c.SectionID)
                .ToList();
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
