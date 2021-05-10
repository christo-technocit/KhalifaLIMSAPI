using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Services.Interfaces
{
    public interface IChartService
    {
        IEnumerable<ViralLoadChartData> GetAllViralLoadChartData(string ReportDateStart, string CompanyName, string Emirate, string ChartNumber);
       // GenericResultWrap GetStat(string FromDate, string ToDate, string Company, string Location, string Station, int ReportType);
        IEnumerable<GenericResult> GetStat(string FromDate, string ToDate, string Company, string Location, string Station, int ReportType);
    }

}
