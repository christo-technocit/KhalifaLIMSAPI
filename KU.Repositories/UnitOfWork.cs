using KU.Repositories.Implementations;
using KU.Repositories.Interfaces;
using System;
using KU.Repositories.Models;
using System.Collections.Generic;
using System.Text;

namespace KU.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        IApplicationUserRepository _ApplicationUser; 

        IApplicationUsersRepository _ApplicationUsers;

        //IAspNetUsersRepository _AspNetUsers;

        ISectionRepository _sections;

        ITemplateRepository _templates;

        ICountryMasterRepository _CountryMaster;

        IFormAttributeRepository _formAttributes;

        IFormAttributeValueRepository _formAttributeValues;

        IFormAttributeValue_filesRepository _formAttributeValue_files;

        ISavedFormRepository _savedForms;

      //  Common _common;

		IQuestionnaireRepository _questionnaire;

      //  IQuestionnaire3Repository _questionnaire3;
      //  IQuestionnaire1Repository _questionnaire1;
    //    IQuestionnaire2Repository _questionnaire2;
      ////  IQuestionnaire2sectionRepository _questionnaire2section;
      //  IQuestionnaire4Repository _questionnaire4;
      //  IQuestionnaire5Repository _questionnaire5;
      //  IQuestionnaire6Repository _questionnaire6;
      //  IQuestionnaire7Repository _questionnaire7;
      //  IQuestionnaire8Repository _questionnaire8;
        ITotalRecordsRepository _totalRecords;
        IGenericResultRepository _GenericResult;

        //public IAspNetUsersRepository AspNetUsers
        //{
        //    get
        //    {
        //        if (_AspNetUsers == null)
        //            _AspNetUsers = new AspNetUsersRepository(_context);

        //        return _AspNetUsers;
        //    }
        //}


        public IApplicationUsersRepository ApplicationUsers
        {
            get
            {
                if (_ApplicationUsers == null)
                    _ApplicationUsers = new ApplicationUsersRepository(_context);

                return _ApplicationUsers;
            }
        }

        public IApplicationUserRepository ApplicationUser
        {
            get
            {
                if (_ApplicationUser == null)
                    _ApplicationUser = new ApplicationUserRepository(_context);

                return _ApplicationUser;
            }
        }

        public ITotalRecordsRepository totalRecords
        {
            get
            {
                if (_totalRecords == null)
                    _totalRecords =  new TotalRecordsRepository(_context);

                return _totalRecords;
            }
        }

        public IGenericResultRepository GenericResult
        {
            get
            {
                if (_GenericResult == null)
                    _GenericResult = new GenericResultRepository(_context);

                return _GenericResult;
            }
        }



        public ICountryMasterRepository CountryMaster
        {
            get
            {
                if ( _CountryMaster == null)
                    _CountryMaster = new CountryMasterRepository(_context);

                return _CountryMaster;
            }
        }
    

        public IQuestionnaireRepository questionnaire
        {
            get
            {
                if (_questionnaire == null)
                    _questionnaire = new QuestionnaireRepository(_context);

                return _questionnaire;
            }
        }


        //public IQuestionnaire1Repository questionnaire1
        //{
        //    get
        //    {
        //        if (_questionnaire1 == null)
        //            _questionnaire1 = new Questionnaire1Repository(_context);

        //        return _questionnaire1;
        //    }
        //}
        //public IQuestionnaire2Repository questionnaire2
        //{
        //    get
        //    {
        //        if (_questionnaire2 == null)
        //            _questionnaire2 = new Questionnaire2Repository(_context);

        //        return _questionnaire2;
        //    }
        //}
        //public IQuestionnaire3Repository questionnaire3 
        //{
        //    get
        //    {
        //        if (_questionnaire3  == null)
        //            _questionnaire3 = new Questionnaire3Repository(_context);

        //        return _questionnaire3;
        //    }
        //}
        //public IQuestionnaire4Repository questionnaire4
        //{
        //    get
        //    {
        //        if (_questionnaire4 == null)
        //            _questionnaire4 = new Questionnaire4Repository(_context);

        //        return _questionnaire4;
        //    }
        //}
        //public IQuestionnaire5Repository questionnaire5
        //{
        //    get
        //    {
        //        if (_questionnaire5 == null)
        //            _questionnaire5 = new Questionnaire5Repository(_context);

        //        return _questionnaire5;
        //    }
        //}
        //public IQuestionnaire6Repository questionnaire6
        //{
        //    get
        //    {
        //        if (_questionnaire6 == null)
        //            _questionnaire6 = new Questionnaire6Repository(_context);

        //        return _questionnaire6;
        //    }
        //}
        //public IQuestionnaire7Repository questionnaire7
        //{
        //    get
        //    {
        //        if (_questionnaire7 == null)
        //            _questionnaire7 = new Questionnaire7Repository(_context);

        //        return _questionnaire7;
        //    }
        //}
        //public IQuestionnaire8Repository questionnaire8
        //{
        //    get
        //    {
        //        if (_questionnaire8 == null)
        //            _questionnaire8 = new Questionnaire8Repository(_context);

        //        return _questionnaire8;
        //    }
        //}
        public IFormAttributeRepository FormAttributes
        {
            get
            {
                if (_formAttributes == null)
                    _formAttributes = new FormAttributeRepository(_context);

                return _formAttributes;
            }
        }

        public IFormAttributeValueRepository FormAttributeValues
        {
            get
            {
                if (_formAttributeValues == null)
                    _formAttributeValues = new FormAttributeValueRepository(_context);

                return _formAttributeValues;
            }
        }
        public IFormAttributeValue_filesRepository FormAttributeValue_files
        {
            get
            {
                if (_formAttributeValue_files == null)
                    _formAttributeValue_files = new FormAttributeValue_filesRepository(_context);

                return _formAttributeValue_files;
            }
        }


        public ISavedFormRepository SavedForms
        {
            get
            {
                if (_savedForms == null)
                    _savedForms = new SavedFormRepository(_context);

                return _savedForms;
            }
        }
        

        public ISectionRepository Sections
        {
            get
            {
                if (_sections == null)
                    _sections = new SectionRepository(_context);

                return _sections;
            }
        }

        public ITemplateRepository Templates
        {
            get
            {
                if (_templates == null)
                    _templates = new TemplateRepository(_context);

                return _templates;
            }
        }

        public int SaveChanges()
        {
         
            return _context.SaveChanges();
        }
     }
}
