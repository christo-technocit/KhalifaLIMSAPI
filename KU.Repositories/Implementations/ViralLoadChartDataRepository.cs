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
    public class ViralLoadChartDataRepository : GenericRepository<ViralLoadChartData>, IViralLoadChartDataRepository
    {
        public ViralLoadChartDataRepository(DbContext context) : base(context)
        { }

        public IEnumerable<ViralLoadChartData> GetAllViralLoadChartData(string ReportDateStart, string CompanyName, string Emirate, string ChartNumber)
        {
            return _appContext.ViralLoadChartData.FromSql("sp_ViralLoadChartData {0}, {1}, {2}, {3}", ReportDateStart, CompanyName, Emirate, ChartNumber)
                .ToList();
        }


   
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

     

    }
}
