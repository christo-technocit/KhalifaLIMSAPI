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
using Newtonsoft.Json;
using KU.Repositories.Models;

namespace KU.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class FormController : ControllerBase
    {
        private readonly IFormService formService;
        readonly ILogger logger;

        public FormController(IFormService formService, ILogger<FormController> logger)
        {
            this.formService = formService;
            this.logger = logger;

        }

        [HttpGet("CheckDuplicate")]
        public IActionResult CheckDuplicate([FromQuery] Int32 MenuID, Int32 SavedFormID, string AttributeName, string AttributeValue)

        {
            try
            {
                var all = formService.CheckDuplicate(MenuID, SavedFormID, AttributeName, AttributeValue);

                return Ok(all);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");

                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }


        [HttpGet("listforms")]
        public IActionResult Get([FromQuery]Int32 MenuId, Int32 SavedFormID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter)
        {
            try
            {
                var all = formService.GetSavedFormByID(MenuId, SavedFormID, orderby, sortorder, pagesize, pagenumber, filter);

                return Ok(all);
            }
            catch (Exception ex)
            {
                 logger.LogError($"Something went wrong: {ex }");
                
                return StatusCode(500, ex.InnerException ) ;
               // return StatusCode(500, "Internal server error" );
                
            }
        }

        [HttpGet("formattributevalues")]
        public IActionResult Get([FromQuery] Int32 SavedFormID)
        {
            try
            { 
            var all = formService.GetFormByID(SavedFormID);
            return Ok(all);
                }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }


        [HttpGet("formattribute")]
        public IActionResult GetAttributeID([FromQuery]string Menuid, string SectionID, string AttributeName)
        {
            try
            {
                var all = formService.GetAttributeID(Menuid, SectionID, AttributeName);
                return Ok(all);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }
        [HttpGet("formattributeReports")]
        public IActionResult GetAttributeIDReports([FromQuery]string Menuid, string SectionID, string AttributeName)
        {
            try
            {
                var all = formService.GetAttributeIDReports(Menuid, SectionID, AttributeName);
                return Ok(all);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }

        [HttpGet("GetForms")]
        public IActionResult GetRecords([FromQuery] Int32 Menuid, Int32 SavedformID,  Int32 SectionID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter, string CompanyName, string FromDate,string ToDate)
        {

            try
            {

               var all = formService.GetRecords(Menuid, SavedformID, SectionID, orderby, sortorder, pagesize, pagenumber, filter,  CompanyName,  FromDate,  ToDate);
                //return Ok(all);
                string[] s = all.Select(p => p.Items).ToArray();
                //string[] s = all.result.Select(p => p.Items).ToArray();
                string jsonResponse = s[0];
                dynamic parsedJson = JsonConvert.DeserializeObject(jsonResponse);
                //return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);

                return Ok(parsedJson);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }

        }


        // GET: api/forms
        [HttpPost("AddForms")]
        //[Authorize(Authorization.Policies.ViewAllCustomersPolicy)]
        public IActionResult AddSavedForm(SavedFormViewModel model)
        {
            try
            {
                var id = formService.InsertSavedForm(model);
                return Ok(id);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }


        [HttpPost("UpdateForms")]
        //[Authorize(Authorization.Policies.ViewAllCustomersPolicy)]
        public IActionResult UpdateSavedForm(SavedFormViewModel model)
        {
            try
            {
                var id = formService.UpdateSavedForm(model);
                return Ok(id);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }

        [HttpPost("DeleteForms")]
        //[Authorize(Authorization.Policies.ViewAllCustomersPolicy)]
        public IActionResult DeleteSavedForm(SavedFormViewModel model)
        {
            try
            {
                var id = formService.DeleteSavedForm(model);
                return Ok(id);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }

               

        // GET: api/forms
        [HttpPost("Addformattributevalue")]
        //[Authorize(Authorization.Policies.ViewAllCustomersPolicy)]
        public IActionResult AddFormAttributeValues(List<FormAttributeValueViewModel> model)
        {
            try
            {
                var status = formService.InsertFormAttributeValues(model);
                return Ok(status);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }

        // GET: api/forms
        [HttpPost("Updateformattributevalue")]
        //[Authorize(Authorization.Policies.ViewAllCustomersPolicy)]
        public IActionResult UpdateFormAttributevalues(List<FormAttributeValueViewModel> model)
        {
            try
            {
                var status = formService.UpdateFormAttributeValues(model);
                return Ok(status);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }
        // GET: api/forms
        [HttpPost("Deleteformattributevalue")]
        //[Authorize(Authorization.Policies.ViewAllCustomersPolicy)]
        public IActionResult DeleteFormAttributevalues(List<FormAttributeValueViewModel> model)
        {
            try
            {
                var status = formService.DeleteFormAttributeValues(model);
                return Ok(status);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }

        // GET: api/forms
        [HttpPost("Addformattributevaluesingle")]
        //[Authorize(Authorization.Policies.ViewAllCustomersPolicy)]
        public IActionResult AddFormAttributeValue(FormAttributeValueViewModel model, long FormAttributeID)
        {
            try
            {
                var id = formService.InsertFormAttributeValue(model);
                var all = formService.MoveImage(id, FormAttributeID);
                return Ok(id);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }

        // GET: api/forms
        [HttpPost("UpdateformattributevalueSingle")]
        //[Authorize(Authorization.Policies.ViewAllCustomersPolicy)]
        public IActionResult Updateformattributevalue(FormAttributeValueViewModel model, long FormAttributeID)
        {
            try
            {
                var id = formService.UpdateFormAttributeValue(model);
                var all = formService.MoveImage(id, FormAttributeID);
                return Ok(id);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }



        // GET: api/forms
        [HttpPost("AddDocuments")]
        //[Authorize(Authorization.Policies.ViewAllCustomersPolicy)]
        public IActionResult AddFormAttributeValues_files(List<FormAttributeValue_filesViewModel> model)
        {
            try
            {
                var status = formService.InsertFormAttributeValues_files(model);
                return Ok(status);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }

        // GET: api/forms
        [HttpPost("UpdateDocuments")]
        //[Authorize(Authorization.Policies.ViewAllCustomersPolicy)]
        public IActionResult UpdateFormAttributevalues_files(List<FormAttributeValue_filesViewModel> model)
        {
            try
            {
                var status = formService.UpdateFormAttributeValues_files(model);
                return Ok(status);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }
        // GET: api/forms
        [HttpPost("DeleteDocuments")]
        //[Authorize(Authorization.Policies.ViewAllCustomersPolicy)]
        public IActionResult DeleteFormAttributevalues_files(List<FormAttributeValue_filesViewModel> model)
        {
            try
            {
                var status = formService.DeleteFormAttributeValues_files(model);
                return Ok(status);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }
        [HttpGet("GetDocuments")]
        public IActionResult GetDocuments([FromQuery] Int32 SavedFormID)
        {
            try
            {
                var all = formService.GetDocumentByID(SavedFormID);
                return Ok(all);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }


        // GET: api/form/Countries
        [HttpGet("Countries")]
        // [Authorize(Authorization.Policies.ViewAllUsersPolicy)]

        public IActionResult GetCountries(string CountryName)
        {
            try
            {
                var all = formService.GetCountries1(CountryName);
                return Ok(all);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }


        // GET: api/form/templates
        [HttpGet("templates")]
        // [Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        public IActionResult GetTemplates(string UserName)
        {
            try
            {
                var all = formService.GetAllTemplates(UserName);
                return Ok(all);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }


 

        [HttpGet("totalrecords")]
        //[Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        public IActionResult GetTotal([FromQuery] Int32 Menuid, Int32 PageSize, string SearchStr)
        {
            try
            {
                var AuthID = Request.Headers["AuthID"];
                var AuthPwd = Request.Headers["AuthPwd"];
                var all = formService.GetTotal(Menuid, PageSize, SearchStr);
                return Ok(all);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }

 [HttpGet("totalrecordswithAuth")]
  

        public IActionResult GetTotalAuth([FromQuery] Int32 Menuid, Int32 PageSize, string SearchStr)
        {
            try
            {
                var AuthID = Request.Headers["AuthID"];

                //var AuthPwd = Request.Headers["AuthPwd"];

                //AuthID = "DAB4986CBE0B430C96A310BB7019D3C0";

                //var all = formService.GetUser(AuthID, AuthPwd);
                var all = formService.CheckToken(AuthID);

                if (all.FirstOrDefault().UserID == 0)
                // if (all.FirstOrDefault().UserId != 0)
                {

                    var totalrec = formService.GetTotal(Menuid, PageSize, SearchStr);
                    return Ok(totalrec);
                }
                else
                {
                    return Ok(all.FirstOrDefault().UserID);

                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }

        //[HttpGet ("ValidateUser")]
        //public IActionResult CheckUser([FromQuery] string UserName, string Password) 
        //{
        //    var all = formService.CheckUserID(UserName, Password);
        //    return Ok(all);
        //}
  
        [HttpGet ("MoveImage")]
            public IActionResult MoveImage (long SavedFormID, long FormAttributeID)
        {
            try
            {
                var all = formService.MoveImage(SavedFormID, FormAttributeID);
                return Ok(all);
            }
            catch (Exception ex)
            {
                
                logger.LogError($"Something went wrong: {ex }");
                return StatusCode(500, ex.InnerException);
                // return StatusCode(500, "Internal server error" );

            }
        }


        [HttpPost("ImportSample")]
        //[HttpPost]
        public async Task<IActionResult> ImportSample( List<SampleForm> Model)

        {
             
            var all = formService.ImportSample(Model,"");
            //  string result = await formService.ImportSample(Model, UserName).ConfigureAwait(false);

            //string[] s = all.Select(p => p.Items).ToArray();
            //string jsonResponse = s[0];
            //dynamic parsedJson = JsonConvert.DeserializeObject(jsonResponse);
            ////return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);

            //return Ok(parsedJson);
            return Ok(all);
        }



    }
}