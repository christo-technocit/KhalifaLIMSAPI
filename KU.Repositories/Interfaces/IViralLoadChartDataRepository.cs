﻿using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Repositories.Interfaces
{
    public interface IViralLoadChartDataRepository : IGenericRepository<ViralLoadChartData>
    {
        
      // TotalRecords_Wrap GetTotal(Int32 TemplateID, Int32 PageSize, string SearchStr);
           IEnumerable<ViralLoadChartData> GetAllViralLoadChartData(string ReportDateStart, string CompanyName, string Emirate, string StationCode, string ChartNumber, Int32 pagesize, Int32 pagenumber);

        IEnumerable<TotalRecords> GetChartRecordTotal(string ReportDateStart, string CompanyName, string Emirate, string StationCode, string ChartNumber, Int32 pagesize, Int32 pagenumber);


    }
}
