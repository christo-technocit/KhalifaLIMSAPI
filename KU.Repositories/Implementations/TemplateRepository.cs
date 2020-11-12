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
    public class TemplateRepository : GenericRepository<Template>, ITemplateRepository
    {
        public TemplateRepository(DbContext context) : base(context)
        { }

        public IEnumerable<Template> GetAllIncludedData(string UserName)
        {
            //return _appContext.Templates
            //    .OrderBy(c => c.TemplateID)
            //    .ToList();
 
            return _appContext.Template
                .OrderBy(c => c.TemplateID)
                .ToList();
        
        }


        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
