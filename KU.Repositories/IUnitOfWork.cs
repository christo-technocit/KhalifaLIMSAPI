using KU.Repositories.Interfaces;
//using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Repositories
{
    public interface IUnitOfWork
    {
        IApplicationUserRepository ApplicationUser { get; }
        IApplicationUsersRepository ApplicationUsers { get; }
        IApplicationUsersRepository ApplicationUsersList { get; }
        IApplicationUsersRepository ApplicationUsersDelete { get; }
 
        IFormAttributeRepository FormAttributes { get; }
        IFormAttributeValueRepository FormAttributeValues { get; }

        
        ISavedFormRepository SavedForms { get; }
        
        ISectionRepository Sections { get; }
        ITemplateRepository Templates { get; }

        ICountryMasterRepository CountryMaster { get; }
		IQuestionnaireRepository questionnaire { get; }

       

        ITotalRecordsRepository totalRecords { get; }
        IGenericResultRepository GenericResult { get; }

        IFormAttributeValue_filesRepository FormAttributeValue_files { get; }

        IViralLoadChartDataRepository ViralLoadChartData { get; }

        int SaveChanges();
    }
}
