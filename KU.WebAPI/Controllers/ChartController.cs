using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KU.Repositories.Models;
using KU.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace KU.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ChartController : ControllerBase
    {
        private readonly IChartService ChartService;
        readonly ILogger logger;
  
        public ChartController(IChartService ChartService, ILogger<ChartController> logger)
        {
            this.ChartService = ChartService;
            this.logger = logger;
        }

        [HttpGet("GetAllViralLoadChartData")]

        //  public IActionResult GetAllViralLoadChartData([FromQuery]string ReportDate)
        public IActionResult GetAllViralLoadChartData([FromQuery]string ReportDateStart, string CompanyName, string Emirate, string ChartNumber)
        {

    //        var all = ChartService.GetAllViralLoadChartData(ReportDate);
//
        //    string[] s = all.Select(p => p.Items).ToArray();
       //     string jsonResponse = s[0];
       //     dynamic parsedJson = JsonConvert.DeserializeObject(jsonResponse);
            //return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);

        //    return Ok(parsedJson);
            //var all = UserService.GetAllIncludedData(OrderBy, SortOrder, PageSize, PageNumber, Filter);
                var all =   ChartService.GetAllViralLoadChartData(ReportDateStart, CompanyName, Emirate, ChartNumber);
              return Ok(all);
        }

    }
}
