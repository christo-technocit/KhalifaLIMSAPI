using KU.Repositories.Interfaces;
using KU.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace KU.Repositories.Implementations
{
    public class FormAttributeRepository : GenericRepository<FormAttribute>, IFormAttributeRepository
    {
        public FormAttributeRepository(DbContext context) : base(context)
        { }

        public IEnumerable<FormAttribute> GetAllIncludedData()
        {
            return _appContext.FormAttribute
                .OrderBy(c => c.TemplateID)
            
                .ToList();
        }

        public IEnumerable<FormAttribute> GetAttributeName(Int32 TemplateID, Int32 FormAttributeID)
        {
            if (TemplateID == 0)
            {
                return _appContext.FormAttribute
                             .OrderBy(c => c.TemplateID)
                             .ToList();
            }
            else
            {
                return _appContext.FormAttribute
             .Where(R => R.TemplateID == TemplateID)
             .OrderBy(c => c.TemplateID)

             .ToList();
            }
        }

        public IEnumerable<FormAttribute> GetAttributeID(string TemplateID, string SectionID, string AttributeName)
        {
           
            if (  string.IsNullOrEmpty(SectionID)) 
            { 
                SectionID = "0"; 
            }


            if ( string.IsNullOrEmpty(TemplateID))
            {
               return _appContext.FormAttribute.FromSql("sp_FormAttribute").ToList();
               // return _appContext.FormAttribute.FromSql("sp_FormAttribute_Check").ToList();

            }
            else
            {
                  if (String.IsNullOrEmpty(AttributeName))  
                    {
                    return _appContext.FormAttribute.FromSql("sp_FormAttribute {0},{1}", TemplateID,SectionID).ToList();
                //    return _appContext.FormAttribute.FromSql("sp_FormAttribute_Check {0},{1}", TemplateID, SectionID).ToList();
                }
                else
                {
                    return _appContext.FormAttribute.FromSql("sp_FormAttribute {0},{1},{2}", TemplateID,SectionID, AttributeName).ToList();
                }
                
            }
        }

        public IEnumerable<FormAttribute> GetAttributeIDReports(string TemplateID, string SectionID, string AttributeName)
        {

            if (string.IsNullOrEmpty(SectionID))
            {
                SectionID = "0";
            }


            if (string.IsNullOrEmpty(TemplateID))
            {
               List<FormAttribute> TR =  _appContext.FormAttribute.FromSql("sp_FormAttribute").ToList();
                return TR;
            }
            else
            {
                if (String.IsNullOrEmpty(AttributeName))
                {
                    List<FormAttribute>  TR =  _appContext.FormAttribute.FromSql("sp_FormAttribute {0},{1}", TemplateID, SectionID).ToList();
                    return TR;
                }
                else
                {
                    List<FormAttribute> TR= _appContext.FormAttribute.FromSql("sp_FormAttribute {0},{1},{2}", TemplateID, SectionID, AttributeName).ToList();
                    return TR;
                }

            }
        }

  
 

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
