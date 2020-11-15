using AutoMapper;
using KU.Repositories;
using KU.Repositories.Models;
using KU.Services.Interfaces;
using KU.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Services.Implementations
{
    public class FormService: IFormService 
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public FormService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<SavedFormViewModel> GetAllSavedForms()
        {
            var all = unitOfWork.SavedForms.GetAllIncludedData();
            
            return mapper.Map<IEnumerable<SavedFormViewModel>>(all);
        }
        public IEnumerable<Template> GetAllTemplates(string UserName)
        {
            var all = unitOfWork.Templates.GetAllIncludedData(UserName);
       return mapper.Map<IEnumerable<Template>>(all);
        }

        public IEnumerable<CountryMaster> GetCountries(string CountryName)
        {
            var all = unitOfWork.CountryMaster.
                GetCountries(CountryName);
            return mapper.Map<IEnumerable<CountryMaster>>(all);
        }

        public CountryWrap GetCountries1(string CountryName)
        {
            var all = unitOfWork.CountryMaster.GetCountries(CountryName);
            return mapper.Map<CountryWrap>(new CountryWrap { result = all });
        }

        public IEnumerable<SavedFormViewModel> GetSavedFormByID(Int32 MenuId, Int32 savedFormID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter)
        {
            var all = unitOfWork.SavedForms.GetSavedFormByID(MenuId, savedFormID, orderby, sortorder, pagesize, pagenumber, filter);
            return mapper.Map<IEnumerable<SavedFormViewModel>>(all);
        }

        // user module begin
        public IEnumerable<Repositories.Models.ApplicationUsers> GetAllIncludedData(Int32 OrderBy, Int32 SortOrder, Int32 PageSize, Int32 PageNumber, string Filter)
        {
            var all = unitOfWork.ApplicationUsers.GetAllIncludedDatas(OrderBy, SortOrder, PageSize, PageNumber, Filter);

            return mapper.Map<IEnumerable<Repositories.Models.ApplicationUsers>>(all);
        }
        public IEnumerable<Repositories.Models.ApplicationUsers> CheckToken(string Token)
        {
            var all = unitOfWork.ApplicationUsers.CheckTokens(Token);
            return mapper.Map<IEnumerable<Repositories.Models.ApplicationUsers>>(all);
        }

        //public IEnumerable<ApplicationUsers> GetUser(string UserName, string Password)
        //{
        //    var all = unitOfWork.ApplicationUsers.GetUser(UserName, Password);
        //    return mapper.Map<IEnumerable<ApplicationUsers>>(all);
        //}

        // user module end

  

        public IEnumerable<FormAttributeValue> GetFormByID (Int32 savedFormID)
        {
            var all = unitOfWork.FormAttributeValues.GetFormByID(savedFormID);
            return mapper.Map<IEnumerable<FormAttributeValue>>(all);
        }
        public IEnumerable<FormAttributeValue_files> GetDocumentByID(Int32 savedFormID)
        {
            var all = unitOfWork.FormAttributeValue_files.GetDocumentByID(savedFormID);
            return mapper.Map<IEnumerable<FormAttributeValue_files>>(all);
        }



        public IEnumerable<FormAttributeValue> MoveImage(long SavedFormID, long FormAttributeID)
        {
            var all = unitOfWork.FormAttributeValues.MoveImage(SavedFormID, FormAttributeID);
           
            return mapper.Map<IEnumerable<FormAttributeValue>>(all);
          
        }
        //public IEnumerable<FormAttributeValue_files> UploadDocument(long FormAttributeValueID, long SavedFormID, string FormAttributeValue)
        //{
        //    var all = unitOfWork.FormAttributeValue_files.UploadDocument(FormAttributeValueID, SavedFormID, FormAttributeValue);
        //    return mapper.Map<IEnumerable<FormAttributeValue_files>>(all);
        //}

        public IEnumerable<FormAttribute> GetAttributeName(Int32 Menuid, Int32 savedFormID)
        {
            var all = unitOfWork.FormAttributes.GetAttributeName(Menuid, savedFormID);
            return mapper.Map<IEnumerable<FormAttribute>>(all);
        }
        public IEnumerable<FormAttribute> GetAttributeID(string TemplateID, string SectionID, String AttributeName)
        {
            var all = unitOfWork.FormAttributes.GetAttributeID(TemplateID, SectionID, AttributeName);
            return mapper.Map<IEnumerable<FormAttribute>>(all);
        }

        public FormAttributeWrap GetAttributeIDReports(string Menuid, string SectionID, String AttributeName)
        {
            var all = unitOfWork.FormAttributes.GetAttributeIDReports(Menuid, SectionID, AttributeName);
            return mapper.Map<FormAttributeWrap>(new FormAttributeWrap { result = all });
        }


        public IEnumerable<GenericResult> GetRecords(Int32 TemplateID,Int32 SavedFormID, Int32 SectionID)
        {
            var all = unitOfWork.GenericResult.GetRecords(TemplateID,SavedFormID, SectionID);
            return mapper.Map<IEnumerable<GenericResult>>(all);
        }


        public IEnumerable<TotalRecords> GetReportTotal(long TemplateID, string SectionID, string AttributeName, string BeginPeriod, string EndPeriod, string CollectedBy, string CollectedPoint, string Nationality, string Gender, string Diabetes, string SampleID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter)
        {
     
            var all = unitOfWork.questionnaire.GetReportTotal(TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, orderby, sortorder, pagesize, pagenumber, filter);
            return mapper.Map<IEnumerable<TotalRecords>>(all);
      
        }


        // Common procedure for reports
        public GenericResultWrap GetReportCommon(long TemplateID, long SectionID, string AttributeName, string BeginPeriod, string EndPeriod, string CollectedBy, string CollectedPoint, string Nationality, string Gender, string Diabetes, string SampleID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter)
        {
            var all = unitOfWork.GenericResult.GetReportCommon(TemplateID, SectionID, AttributeName, BeginPeriod, EndPeriod, CollectedBy, CollectedPoint, Nationality, Gender, Diabetes, SampleID, orderby, sortorder, pagesize, pagenumber, filter);
            return mapper.Map<GenericResultWrap>(new GenericResultWrap { result = all });
        }

        //



        // to print with result head
        //public TotalRecordsWrap GetTotal(Int32 TemplateID, Int32 PageSize, string SearchStr)
        //{
        //    var all = unitOfWork.totalRecords.GetTotal(TemplateID, PageSize, SearchStr);
        //    return mapper.Map<TotalRecordsWrap>(new TotalRecordsWrap { result = all });
        //}
        public IEnumerable<TotalRecords> GetTotal(Int32 TemplateID, Int32 PageSize, string SearchStr)
        {
            var all = unitOfWork.totalRecords.GetTotal(TemplateID, PageSize, SearchStr);
            return mapper.Map<IEnumerable<TotalRecords>>(all);
        }

        public long InsertSavedForm(SavedFormViewModel model)
        {
            var entity = mapper.Map<SavedForm>(model);
            unitOfWork.SavedForms.Add(entity);
            unitOfWork.SaveChanges();
            return entity.SavedFormID;
        }
        public long UpdateSavedForm(SavedFormViewModel model)
        {
            var entity = mapper.Map<SavedForm>(model);
            unitOfWork.SavedForms.Update(entity);
            unitOfWork.SaveChanges();
            return entity.SavedFormID;
        }

        public long DeleteSavedForm (SavedFormViewModel model)
        {
            var entity = mapper.Map<SavedForm>(model);
            unitOfWork.SavedForms.Remove(entity);
            unitOfWork.SaveChanges();
            return entity.SavedFormID;
        }

        //


        public bool InsertFormAttributeValues(List<FormAttributeValueViewModel> model)
        {
            var entities = mapper.Map<List<FormAttributeValue>>(model);
            unitOfWork.FormAttributeValues.AddRange(entities);
            unitOfWork.SaveChanges();
            return true;
        }
        public bool UpdateFormAttributeValues(List<FormAttributeValueViewModel> model)
        {
            var entities = mapper.Map<List<FormAttributeValue>>(model);

            unitOfWork.FormAttributeValues.UpdateRange(entities);

            unitOfWork.SaveChanges();
            return true;
        }
        public bool DeleteFormAttributeValues(List<FormAttributeValueViewModel> model)
        {
            var entities = mapper.Map<List<FormAttributeValue>>(model);

            unitOfWork.FormAttributeValues.RemoveRange(entities);

            unitOfWork.SaveChanges();
            return true;
        }


        public long InsertFormAttributeValue(FormAttributeValueViewModel model)
        {
            var entity = mapper.Map<FormAttributeValue>(model);
            unitOfWork.FormAttributeValues.Add(entity);
            unitOfWork.SaveChanges();
            return entity.SavedFormID;
        }
        public long UpdateFormAttributeValue(FormAttributeValueViewModel model)
        {
            var entity = mapper.Map<FormAttributeValue>(model);
            unitOfWork.FormAttributeValues.Update(entity);
            unitOfWork.SaveChanges();
            return entity.SavedFormID ;
        }

        

        public bool InsertFormAttributeValues_files(List<FormAttributeValue_filesViewModel> model)
        {
            var entities = mapper.Map<List<FormAttributeValue_files>>(model);
            unitOfWork.FormAttributeValue_files.AddRange(entities);
            unitOfWork.SaveChanges();
            return true;
        }

        public bool UpdateFormAttributeValues_files(List<FormAttributeValue_filesViewModel> model)
        {
            var entities = mapper.Map<List<FormAttributeValue_files>>(model);
            unitOfWork.FormAttributeValue_files.UpdateRange(entities);
            unitOfWork.SaveChanges();
            return true;
        }
        public bool DeleteFormAttributeValues_files(List<FormAttributeValue_filesViewModel> model)
        {
            var entities = mapper.Map<List<FormAttributeValue_files>>(model);
            unitOfWork.FormAttributeValue_files.RemoveRange(entities);
            unitOfWork.SaveChanges();
            return true;
        }


    }
}
