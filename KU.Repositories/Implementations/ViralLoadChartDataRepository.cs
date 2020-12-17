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

        public IEnumerable<ViralLoadChartData> GetAllViralLoadChartData(string ReportDateStart, string CompanyName, string Emirate, string StationCode, string ChartNumber, Int32 pagesize, Int32 pagenumber)
        {
            return _appContext.ViralLoadChartData.FromSql("sp_ViralLoadChartData1 {0}, {1}, {2}, {3}, {4}, {5}, {6}", ReportDateStart, CompanyName, Emirate, StationCode, ChartNumber, pagesize, pagenumber)
                .ToList();
        }

        public IEnumerable<TotalRecords> GetChartRecordTotal(string ReportDateStart, string CompanyName, string Emirate, string StationCode, string ChartNumber, Int32 pagesize, Int32 pagenumber)
        {
            return _appContext.Totalrecords.FromSql("sp_ViralLoadChartData_Count {0}, {1}, {2}, {3}, {4}, {5}, {6}", ReportDateStart, CompanyName, Emirate, StationCode, ChartNumber, pagesize, pagenumber)
                .ToList();
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

     

    }
}
