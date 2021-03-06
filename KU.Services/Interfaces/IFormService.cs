﻿using KU.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Services.Interfaces
{
    public interface IFormService
    {
        // user module begin
        IEnumerable<ApplicationUsers> GetAllIncludedData(Int32 OrderBy, Int32 SortOrder, Int32 PageSize, Int32 PageNumber, string Filter);
        //   IEnumerable<ApplicationUsers> GetUser(string UserName, string Password);

        IEnumerable<ApplicationUsers> CheckToken(string token);

        // user module end
        IEnumerable<SavedFormViewModel> GetAllSavedForms();
        
        IEnumerable<Template> GetAllTemplates(string UserName);
        IEnumerable<CountryMaster> GetCountries(string CountryName);
        CountryWrap GetCountries1(string CountryName);
        IEnumerable<SavedFormViewModel> GetSavedFormByID(Int32 MenuId, Int32 SavedFormID, Int32 orderby, Int32 sortorder ,Int32 pagesize, Int32 pagenumber, string filter);
        
        

        IEnumerable<FormAttributeValue> GetFormByID(Int32 SavedFormID);
        IEnumerable<FormAttributeValue_files> GetDocumentByID(Int32 SavedFormID);
    
        IEnumerable<FormAttributeValue> MoveImage(long SavedFormID, long FormAttributeID);
      //  IEnumerable<FormAttributeValue_files> UploadDocument(long FormAttributeValueID, long SavedFormID, string FormAttributeValue);

         // IEnumerable<SavedFormViewModel> GetFormByID(Int32 TemplateID, Int32 SavedFormID);

        IEnumerable <FormAttribute> GetAttributeName(Int32 Menuid, Int32 savedFormID);
        IEnumerable<FormAttribute> GetAttributeID(string Menuid, string SectionID, string AttributeName);
        FormAttributeWrap GetAttributeIDReports(string Menuid, string SectionID, string AttributeName);



        //to print with result head
        // TotalRecordsWrap GetTotal(Int32 TemplateID, Int32 PageSize, String SearchStr);
        IEnumerable<TotalRecords> GetTotal(Int32 TemplateID, Int32 PageSize, String SearchStr);

        //TotalRecordsWrap GetReportTotal(long TemplateID, string SectionID, string AttributeName, string BeginPeriod, string EndPeriod, string CollectedBy, string CollectedPoint, string Nationality, string Gender, string Diabetes, string SampleID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter);
        IEnumerable<TotalRecords> GetReportTotal(long MenuID, string SectionID, string AttributeName, string SampleCollectionDateFrom, string SampleCollectionDateTo, string ReceivingDateFrom, string ReceivingDateTo, string KUReference, string Location, string StationCode, string CompanyName, string SampleType, string SampleSubType, string SampleCollectionType, string CollectedBy, string Emirate, string SampleID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string Filter);

        //Common Procedure

        IEnumerable<GenericResult> ImportSample(List<SampleForm> Model, string UserName); 
        IEnumerable<GenericResult> GetRecords(Int32 MenuID, Int32 SavedFormID, Int32 SectionID, Int32 orderby, Int32 sortorder, Int32 pagesize, Int32 pagenumber, string filter, string CompanyName, string FromDate, string ToDate);
        GenericResultWrap GetReportCommon(int orderby, int sortorder, int pagesize, int pagenumber, string MenuID, string SectionID, string AttributeName, string SampleCollectionDateFrom, string SampleCollectionDateTo, string ReceivingDateFrom, string ReceivingDateTo, string KUReference, string Location, string StationCode, string CompanyName, string SampleType, string SampleSubType, string SampleCollectionType, string CollectedBy, string Emirate, string SampleID, string Filter);
        //GenericResultWrap CheckDuplicate(Int32 MenuID, Int32 SavedFormID, string AttributeName, string AttributeValue);
        IEnumerable<GenericResult> CheckDuplicate(Int32 MenuID, Int32 SavedFormID, string AttributeName, string AttributeValue);

        long InsertSavedForm(SavedFormViewModel model );
        long UpdateSavedForm(SavedFormViewModel model);
        long DeleteSavedForm(SavedFormViewModel model);

        bool InsertFormAttributeValues(List<FormAttributeValueViewModel> model);
        bool UpdateFormAttributeValues(List<FormAttributeValueViewModel> model);
        bool DeleteFormAttributeValues(List<FormAttributeValueViewModel> model);

        long InsertFormAttributeValue(FormAttributeValueViewModel model);
        long UpdateFormAttributeValue(FormAttributeValueViewModel model);
       

        bool InsertFormAttributeValues_files(List<FormAttributeValue_filesViewModel> model);
        bool UpdateFormAttributeValues_files(List<FormAttributeValue_filesViewModel> model);
        bool DeleteFormAttributeValues_files(List<FormAttributeValue_filesViewModel> model);
    }
}
