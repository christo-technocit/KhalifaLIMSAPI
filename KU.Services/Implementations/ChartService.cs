using AutoMapper;
using KU.Repositories;
using KU.Repositories.Models;
using KU.Services.Interfaces;
using KU.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Services.Implementations
{
    public class ChartService: IChartService 
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ChartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public IEnumerable<ViralLoadChartData> GetAllViralLoadChartData(string ReportDateStart, string CompanyName, string Emirate, string ChartNumber)
        {
            var all = unitOfWork.ViralLoadChartData.GetAllViralLoadChartData(ReportDateStart, CompanyName, Emirate, ChartNumber);
            return mapper.Map<IEnumerable<ViralLoadChartData>>(all);
        }

        //public GenericResultWrap GetStat(string FromDate, string ToDate, string Company, string Location, string Station, int ReportType)
        //{
        //    var all = unitOfWork.GenericResult.GetStat(FromDate, ToDate, Company, Location, Station, ReportType);
        //    return mapper.Map<GenericResultWrap>(new GenericResultWrap { result = all });
        //}

        public IEnumerable<GenericResult> GetStat(string FromDate, string ToDate, string Company, string Location, string Station, int ReportType)
        {
            var all = unitOfWork.GenericResult.GetStat(FromDate, ToDate, Company, Location, Station, ReportType);
            return mapper.Map<IEnumerable<GenericResult>>(all);
        }

    }
}
