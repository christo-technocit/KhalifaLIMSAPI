using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
//namespace IC6.Xamarin.WebApi.Controllers


using System.Collections.Generic;

using System.Linq;

using KU.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;



namespace KU.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Image")]
   // [ApiController]
    public class ImageController : ControllerBase
    {
        //private readonly IImageService ImageService;
        //readonly ILogger logger;

        //public ImageController(IImageService ImageService, ILogger<ImageController> logger)
        //{
        //    this.ImageService = ImageService;
        //    this.logger = logger;
        //}

        private readonly IFormService FormService;
        readonly ILogger logger;
        private readonly IHostingEnvironment _environment;

        public ImageController(IHostingEnvironment environment, IFormService FormService, ILogger<ImageController> logger)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            this.FormService = FormService;
            this.logger = logger;
        }

        //private readonly IHostingEnvironment _environment;

        //public ImageController(IHostingEnvironment environment)
        //{
        //    _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        //}


        // POST: api/Image
        [HttpPost]
       public async Task Post(IFormFile file, string foldername, Int32 SavedFormID)
       {

             //var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            var uploads = Path.Combine(_environment.ContentRootPath, foldername);
            if (file.Length > 0)
            {
                var newfilename = file.FileName;
                newfilename = SavedFormID.ToString()+"_"+newfilename;

                //using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Append))
                using (var fileStream = new FileStream(Path.Combine(uploads, newfilename), FileMode.Append))
                {

                    await file.CopyToAsync(fileStream);
                }

            }

        }

        /////
       
    
                ///

    }

}