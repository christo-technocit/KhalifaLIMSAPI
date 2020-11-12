using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KU.Repositories.Models;
using KU.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace KU.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService UserService;
        readonly ILogger logger;
  
        public UsersController(IUserService UserService, ILogger<UsersController> logger)
        {
            this.UserService = UserService;
            this.logger = logger;
        }





        [HttpGet("ValidateUser")]
        public IActionResult CheckUser([FromQuery] string UserName, string Password)
        {
          
            var all = UserService.CheckUserIDs(UserName, Password);
            return Ok(all);
        }

        [HttpGet("GetAllUser")]
        //[Authorize(Authorization.Policies.ViewAllUsersPolicy)]
       // [Authorize]
        public IActionResult GetUser (Int32 OrderBy, Int32 SortOrder, Int32 PageSize, Int32 PageNumber, string Filter)
        {


            //var all = UserService.GetAllIncludedData(OrderBy, SortOrder, PageSize, PageNumber, Filter);
            var all = UserService.GetAllIncludedDatas(OrderBy, SortOrder, PageSize, PageNumber, Filter);
            return Ok(all);
        }


        [HttpPost("AddUser")]
        //[Authorize(Authorization.Policies.ViewAllCustomersPolicy)]
        public IActionResult AddUser(ApplicationUsersViewModel model)
        {
            var id = UserService.InsertUser(model);
            return Ok(id);
        }


        [HttpPost("UpdateUser")]
        //[Authorize(Authorization.Policies.ViewAllCustomersPolicy)]
        public IActionResult UpdateUser(ApplicationUsersViewModel model)
        {
            var id = UserService.UpdateUser(model);
            return Ok(id);
        }

        [HttpPost("DeleteUser")]
        //[Authorize(Authorization.Policies.ViewAllCustomersPolicy)]
        public IActionResult DeleteUser(ApplicationUsersViewModel model)
        {
            var id = UserService.DeleteUser(model);
            return Ok(id);
        }

        [HttpGet("GetMenu")]
        public async Task<IActionResult> GetMenu([FromQuery] string UserName)

        {

            var all = UserService.GetMenu(UserName);

            string[] s = all.Select(p => p.Items).ToArray();
            string jsonResponse = s[0];
            dynamic parsedJson = JsonConvert.DeserializeObject(jsonResponse);
            //return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);

            return Ok(parsedJson);
        }

        [HttpGet("GetTemplate")]
        public async Task<IActionResult> GetTemplate([FromQuery] string UserName)

        {

            var all = UserService.GetTemplate(UserName);

            string[] s = all.Select(p => p.Items).ToArray();
            string jsonResponse = s[0];
            dynamic parsedJson = JsonConvert.DeserializeObject(jsonResponse);
            //return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);

            return Ok(parsedJson);
        }

        [HttpGet("GetReportTemplate")]
        public async Task<IActionResult> GetReportTemplate([FromQuery] string UserName)

        {

            var all = UserService.GetReportTemplate(UserName);

            string[] s = all.Select(p => p.Items).ToArray();
            string jsonResponse = s[0];
            dynamic parsedJson = JsonConvert.DeserializeObject(jsonResponse);
            //return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);

            return Ok(parsedJson);
        }

        // GET: api/Users/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<AspNetUsers>> GetAspNetUsers(string id)
        //{
        //    var aspNetUsers = await _context.AspNetUser.FindAsync(id);

        //    if (aspNetUsers == null)
        //    {
        //        return NotFound();
        //    }

        //    return aspNetUsers;
        //}

        //// PUT: api/Users/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAspNetUsers(string id, AspNetUsers aspNetUsers)
        //{
        //    if (id != aspNetUsers.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(aspNetUsers).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AspNetUsersExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Users
        //[HttpPost]
        //public async Task<ActionResult<AspNetUsers>> PostAspNetUsers(AspNetUsers aspNetUsers)
        //{
        //    _context.AspNetUser.Add(aspNetUsers);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAspNetUsers", new { id = aspNetUsers.Id }, aspNetUsers);
        //}

        //// DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<AspNetUsers>> DeleteAspNetUsers(string id)
        //{
        //    var aspNetUsers = await _context.AspNetUser.FindAsync(id);
        //    if (aspNetUsers == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.AspNetUser.Remove(aspNetUsers);
        //    await _context.SaveChangesAsync();

        //    return aspNetUsers;
        //}

        //private bool AspNetUsersExists(string id)
        //{
        //    return _context.AspNetUser.Any(e => e.Id == id);
        //}


    }
}
