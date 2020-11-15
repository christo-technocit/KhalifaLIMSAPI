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
                .OrderBy(c => c.MenuID)
            
                .ToList();
        }

        public IEnumerable<FormAttribute> GetAttributeName(Int32 Menuid, Int32 FormAttributeID)
        {
            if (Menuid == 0)
            {
                return _appContext.FormAttribute
                             .OrderBy(c => c.MenuID)
                             .ToList();
            }
            else
            {
                return _appContext.FormAttribute
             .Where(R => R.MenuID == Menuid)
             .OrderBy(c => c.MenuID)

             .ToList();
            }
        }

        public IEnumerable<FormAttribute> GetAttributeID(string Menuid, string SectionID, string AttributeName)
        {
           
            if (  string.IsNullOrEmpty(SectionID)) 
            { 
                SectionID = "0"; 
            }


            if ( string.IsNullOrEmpty(Menuid))
            {
               return _appContext.FormAttribute.FromSql("sp_FormAttribute").ToList();

            }
            else
            {
                  if (String.IsNullOrEmpty(AttributeName))  
                    {
                    return _appContext.FormAttribute.FromSql("sp_FormAttribute {0},{1}", Menuid, SectionID).ToList();
                }
                else
                {
                    return _appContext.FormAttribute.FromSql("sp_FormAttribute {0},{1},{2}", Menuid, SectionID, AttributeName).ToList();
                }
                
            }
        }

        public IEnumerable<FormAttribute> GetAttributeIDReports(string Menuid, string SectionID, string AttributeName)
        {

            if (string.IsNullOrEmpty(SectionID))
            {
                SectionID = "0";
            }


            if (string.IsNullOrEmpty(Menuid))
            {
               List<FormAttribute> TR =  _appContext.FormAttribute.FromSql("sp_FormAttribute").ToList();
                return TR;
            }
            else
            {
                if (String.IsNullOrEmpty(AttributeName))
                {
                    List<FormAttribute>  TR =  _appContext.FormAttribute.FromSql("sp_FormAttribute {0},{1}", Menuid, SectionID).ToList();
                    return TR;
                }
                else
                {
                    List<FormAttribute> TR= _appContext.FormAttribute.FromSql("sp_FormAttribute {0},{1},{2}", Menuid, SectionID, AttributeName).ToList();
                    return TR;
                }

            }
        }

  
 

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
