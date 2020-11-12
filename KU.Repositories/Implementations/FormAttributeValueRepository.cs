using KU.Repositories.Interfaces;
using KU.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.IO;

namespace KU.Repositories.Implementations
{
    public class FormAttributeValueRepository : GenericRepository<FormAttributeValue>, IFormAttributeValueRepository
    {
        public FormAttributeValueRepository(DbContext context) : base(context)
        { }

        public IEnumerable<FormAttributeValue> GetAllIncludedData()
        {
            return _appContext.FormAttributeValue
                .OrderBy(c => c.FormAttributeID)
                .ToList();
        }

        public IEnumerable<FormAttributeValue> GetFormByID(Int32 SavedFormID)
        {

            return _appContext.FormAttributeValue .Where (R => R.SavedFormID == SavedFormID)
            .OrderBy(c => c.SavedFormID)
            .ToList();



        }

        public IEnumerable<FormAttributeValue> MoveImage (long SavedFormID, long FormAttributeID)
        {
            //string path= "C:\\TCIT\\Khalifa University\\Khalifa\\KU.WebAPI\\TempImages";
            //string path2= "C:\\TCIT\\Khalifa University\\Khalifa\\KU.WebAPI\\TempImages";
     
            //if (!File.Exists(path))
            //{
            //    // This statement ensures that the file is created,
            //    // but the handle is not kept.
            //    using (FileStream fs = File.Create(path)) { }
            //}

            //// Ensure that the target does not exist.
            //if (File.Exists(path2))
            //    File.Delete(path2);

            //// Move the file.
            //File.Move(path, path2);


    
            return _appContext.FormAttributeValue.FromSql("sp_moveimage {0},{1}", SavedFormID, FormAttributeID);
        }

        public IEnumerable<FormAttributeValue> ReadExcel(long SavedFormID, long FormAttributeID)
        {


            return _appContext.FormAttributeValue.FromSql("sp_moveimage {0},{1}", SavedFormID, FormAttributeID);
        }


        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
