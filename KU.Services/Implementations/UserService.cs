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
    public class UserService: IUserService 
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        // user module begin
        public IEnumerable<ApplicationUser> GetAllIncludedData(Int32 OrderBy, Int32 SortOrder, Int32 PageSize, Int32 PageNumber, string Filter)
        {
            var all = unitOfWork.ApplicationUser.GetAllIncludedData(OrderBy, SortOrder, PageSize, PageNumber, Filter);

            return mapper.Map<IEnumerable<ApplicationUser>>(all);
        }
        //public IEnumerable<ApplicationUsers> GetUser(string UserName, string Password)
        //{
        //    var all = unitOfWork.ApplicationUsers.GetUser(UserName, Password);
        //    return mapper.Map<IEnumerable<ApplicationUsers>>(all);
        //}

        /// <summary>
        /// /////////////////////////////////////////////////////
        /// 
        public IEnumerable<GenericResult> GetMenu(string UserName)
        {
            var all = unitOfWork.GenericResult.GetMenu(UserName);

            return mapper.Map<IEnumerable<GenericResult>>(all);
        }
        public IEnumerable<GenericResult> GetTemplate(string UserName)
        {
            var all = unitOfWork.GenericResult.GetTemplate(UserName);

            return mapper.Map<IEnumerable<GenericResult>>(all);
        }
        public IEnumerable<GenericResult> GetReportTemplate(string UserName)
        {
            var all = unitOfWork.GenericResult.GetReportTemplate(UserName);

            return mapper.Map<IEnumerable<GenericResult>>(all);
        }

        public IEnumerable<ApplicationUsers> GetAllIncludedDatas(Int32 OrderBy, Int32 SortOrder, Int32 PageSize, Int32 PageNumber, string Filter)
        {
            var all = unitOfWork.ApplicationUsers.GetAllIncludedDatas(OrderBy, SortOrder, PageSize, PageNumber, Filter);

            return mapper.Map<IEnumerable<ApplicationUsers>>(all);
        }

        public IEnumerable<ApplicationUsers> CheckUserIDs(string UserName, string Password)
        {
            var all = unitOfWork.ApplicationUsers.CheckUserIDs(UserName, Password);
            return mapper.Map<IEnumerable<ApplicationUsers>>(all);
        }


        public IEnumerable<ApplicationUsers> CheckTokens(string Token)
        {
            var all = unitOfWork.ApplicationUsers.CheckTokens(Token);
            return mapper.Map<IEnumerable<ApplicationUsers>>(all);
        }


        public string InsertUser(ApplicationUsersViewModel model)
        {
            var entity = mapper.Map<ApplicationUsers>(model);
            unitOfWork.ApplicationUsers.Add(entity);
            unitOfWork.SaveChanges();
            return entity.UserId;
        }
        public string UpdateUser(ApplicationUsersViewModel model)
        {
            var entity = mapper.Map<ApplicationUsers>(model);
            unitOfWork.ApplicationUsers.Update(entity);
            unitOfWork.SaveChanges();
            return entity.UserId;
        }

        public string DeleteUser(ApplicationUsersViewModel model)
        {
            var entity = mapper.Map<ApplicationUsers>(model);
            unitOfWork.ApplicationUsers.Remove(entity);
            unitOfWork.SaveChanges();
            return entity.UserId;
        }

        // user module end

    }
}
