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
    public class FormAttributeValue_filesRepository : GenericRepository<FormAttributeValue_files>, IFormAttributeValue_filesRepository
    {
        public FormAttributeValue_filesRepository(DbContext context) : base(context)
        { }

        public IEnumerable<FormAttributeValue_files> GetDocumentByID(Int32 SavedFormID)
        {

            return _appContext.formAttributeValue_Files.Where(R => R.SavedFormID == SavedFormID)
            .OrderBy(c => c.SavedFormID)
            .ToList();



        }

        //public IEnumerable<FormAttributeValue_files> UploadDocument (long FormAttributeValueID, long SavedFormID, string FormAttributeValue)
        //{

        //    return _appContext.formAttributeValue_Files.FromSql("sp_UploadDocument {0},{1},{2}", FormAttributeValueID, SavedFormID,  FormAttributeValue);
        //}

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
