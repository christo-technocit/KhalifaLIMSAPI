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



        // IAspNetUsersRepository AspNetUsers { get; }

        IFormAttributeRepository FormAttributes { get; }
        IFormAttributeValueRepository FormAttributeValues { get; }

        
        ISavedFormRepository SavedForms { get; }
        
        ISectionRepository Sections { get; }
        ITemplateRepository Templates { get; }

        ICountryMasterRepository CountryMaster { get; }
		IQuestionnaireRepository questionnaire { get; }

       // Common common { get; }

        //      IQuestionnaire3Repository  questionnaire3 { get; }
        //      IQuestionnaire1Repository questionnaire1 { get; }
        //   IQuestionnaire2Repository questionnaire2 { get; }

        //     // IQuestionnaire2sectionRepository questionnaire2section { get; }

        //IQuestionnaire4Repository questionnaire4 { get; }
        //      IQuestionnaire5Repository questionnaire5 { get; }
        //      IQuestionnaire6Repository questionnaire6 { get; }
        //      IQuestionnaire7Repository questionnaire7 { get; }
        //      IQuestionnaire8Repository questionnaire8 { get; }

        ITotalRecordsRepository totalRecords { get; }
        IGenericResultRepository GenericResult { get; }

        IFormAttributeValue_filesRepository FormAttributeValue_files { get; }

        int SaveChanges();
    }
}
