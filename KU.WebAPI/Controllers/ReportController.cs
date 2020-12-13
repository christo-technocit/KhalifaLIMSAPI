using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KU.Services.Interfaces;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace KU.WebAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]

  

    public class ReportController : ControllerBase
    {
        private readonly IFormService formService;
        readonly ILogger logger;





        public ReportController(IFormService formService, ILogger<FormController> logger)
        {
            this.formService = formService;
            this.logger = logger;

        }




        [EnableCors("MyPolicy")]
        [HttpGet("Reports")]
        public IActionResult GetReport([FromQuery] int orderby, int sortorder, int pagesize, int pagenumber, string MenuID, string SectionID, string AttributeName, string SampleCollectionDateFrom, string SampleCollectionDateTo, string ReceivingDateFrom, string ReceivingDateTo, string KUReference, string Location, string StationCode, string CompanyName, string SampleType, string SampleSubType, string SampleCollectionType, string CollectedBy, string Emirate, string SampleID, string Filter)
        {

            try
            {
                var all = formService.GetReportCommon(orderby, sortorder, pagesize, pagenumber, MenuID, SectionID, AttributeName, SampleCollectionDateFrom, SampleCollectionDateTo, ReceivingDateFrom, ReceivingDateTo, KUReference, Location, StationCode, CompanyName, SampleType, SampleSubType, SampleCollectionType, CollectedBy, Emirate, SampleID, Filter);

                //string[] s = all.Select(p => p.Items).ToArray();
                string[] s = all.result.Select(p => p.Items).ToArray();
                string jsonResponse = s[0];
                jsonResponse = "{ result :" + jsonResponse + "}";
                dynamic parsedJson = JsonConvert.DeserializeObject(jsonResponse);
                //return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);

                return Ok(parsedJson);
            }
            catch (Exception ex)
            {
                //logger.LogError($"Something went wrong ex: {ex }");
                logger.LogError($"Something went wrong ex: {ex.Message }");
                return StatusCode(500, ex.Message);
                // return StatusCode(500, "Internal server error" );

            }
        }

        [EnableCors("MyPolicy")]
        [HttpGet("ReportTotal")]
        public IActionResult GetReportTotal([FromQuery] long TemplateID, string SectionID, string AttributeName, string BeginPeriod, string EndPeriod, string CollectedBy, string CollectedPoint, string Nationality, string Gender, string Diabetes, string SampleID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter)
        {
      
            try { 
            var all1 = formService.GetReportTotal(TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, orderby, sortorder, pagesize, pagenumber, filter);


                return Ok(all1);
            }
            catch (Exception ex)
            {


                logger.LogError($"Something went wrong ex: {ex.Message }");

                return StatusCode(500, ex.Message );
                // return StatusCode(500, "Internal server error" );

            }
        }


    }
}