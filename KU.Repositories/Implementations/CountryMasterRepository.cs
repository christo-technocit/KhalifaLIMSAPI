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
    public class CountryMasterRepository : GenericRepository<CountryMaster>, ICountryMasterRepository
    {
        public CountryMasterRepository(DbContext context) : base(context)
        { }

        public IEnumerable<CountryMaster> GetCountries(string CountryName)
        {

            if (string.IsNullOrWhiteSpace(CountryName))
            {
                CountryName = "";
            }

            List<CountryMaster> TR= _appContext.CountryMaster
            .FromSql("sp_CountryMaster {0}",CountryName)
            .OrderBy(c => c.CountryName)
            .ToList();
            return TR;
            

            //return _appContext.CountryMaster
            //.FromSql("sp_CountryMaster {0}", CountryName)
            //.OrderBy(c => c.CountryName)
            //.ToList();
          
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
