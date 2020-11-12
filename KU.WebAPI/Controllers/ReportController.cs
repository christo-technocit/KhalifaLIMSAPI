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
        public IActionResult GetReport([FromQuery] long TemplateID, long SectionID, string AttributeName, string BeginPeriod, string EndPeriod, string CollectedBy, string CollectedPoint, string Nationality, string Gender, string Diabetes, string SampleID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter)
        {

            try
            {
                //if (TemplateID == 1)
                //{
                //    var all = formService.GetReport(TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, orderby, sortorder, pagesize, pagenumber, filter);
                //    return Ok(all);
                //}

                //if (TemplateID == 2)
                //{
                //    var all = formService.GetReport2(TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, orderby, sortorder, pagesize, pagenumber, filter);
                //    return Ok(all);
                //}
                //if (TemplateID == 4)
                //{
                //    var all = formService.GetReport3(TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, orderby, sortorder, pagesize, pagenumber, filter);
                //    return Ok(all);
                //}
                //if (TemplateID == 5)
                //{
                //    var all = formService.GetReport4(TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, orderby, sortorder, pagesize, pagenumber, filter);
                //    return Ok(all);
                //}
                //if (TemplateID == 6)
                //{
                //    var all = formService.GetReport5(TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, orderby, sortorder, pagesize, pagenumber, filter);
                //    return Ok(all);
                //}
                //if (TemplateID == 7)
                //{
                //    var all = formService.GetReport6(TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, orderby, sortorder, pagesize, pagenumber, filter);
                //    return Ok(all);
                //}

                //if (TemplateID == 8)
                //{
                //    var all = formService.GetReport7(TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, orderby, sortorder, pagesize, pagenumber, filter);
                //    return Ok(all);
                //}

                //if (TemplateID == 9)
                //{
                //    var all = formService.GetReport8(TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, orderby, sortorder, pagesize, pagenumber, filter);
                //    return Ok(all);
                //}

                //if (TemplateID == 10 && SectionID == 0)
                //{
                //    var all = formService.GetReport9(TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, orderby, sortorder, pagesize, pagenumber, filter);
                //    return Ok(all);
                //}
                //if (TemplateID == 10 && SectionID == 9)
                //{
                //    var all = formService.GetReport9_9(TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, orderby, sortorder, pagesize, pagenumber, filter);
                //    return Ok(all);
                //}
                //if (TemplateID == 11)
                //{
                //    var all = formService.GetReport10(TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, orderby, sortorder, pagesize, pagenumber, filter);
                //    return Ok(all);
                //}

                //var all1 = formService.GetReport(TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, orderby, sortorder, pagesize, pagenumber, filter);
                //return Ok(all1);

                var all = formService.GetReportCommon(TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, orderby, sortorder, pagesize, pagenumber, filter);

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


        //[EnableCors("MyPolicy")]
        //[HttpGet("ReportNew")]
        //public async Task<IActionResult> GetReportNew([FromQuery] long TemplateID, long SectionID, string AttributeName, string BeginPeriod, string EndPeriod, string CollectedBy, string CollectedPoint, string Nationality, string Gender, string Diabetes, string SampleID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter)

        //{

        //    var all = formService.GetReportCommon(TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, orderby, sortorder, pagesize, pagenumber, filter);

        //    //string[] s = all.Select(p => p.Items).ToArray();
        //    string[] s = all.result.Select(p => p.Items).ToArray();
        //    string jsonResponse = s[0];
        //    jsonResponse = "{ result :" + jsonResponse + "}";
        //    dynamic parsedJson = JsonConvert.DeserializeObject(jsonResponse);
        //    //return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);

        //    return Ok(parsedJson);
        //}




    }
}