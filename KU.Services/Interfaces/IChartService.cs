using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Services.Interfaces
{
    public interface IChartService
    {
        IEnumerable<ViralLoadChartData> GetAllViralLoadChartData(string ReportDateStart, string CompanyName, string Emirate, string ChartNumber);
    }
}
