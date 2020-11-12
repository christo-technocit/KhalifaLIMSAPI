using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KU.WebAPI.Authorization
{
    public class Policies
    {
        ///<summary>Policy to allow viewing all user records.</summary>
        public const string ViewAllUsersPolicy = "View All Users";

        ///<summary>Policy to allow adding, removing and updating all user records.</summary>
        public const string ManageAllUsersPolicy = "Manage All Users";

        /// <summary>Policy to allow viewing details of all roles.</summary>
        public const string ViewAllRolesPolicy = "View All Roles";

        /// <summary>Policy to allow viewing details of all or specific roles (Requires roleName as parameter).</summary>
        public const string ViewRoleByRoleNamePolicy = "View Role by RoleName";

        /// <summary>Policy to allow adding, removing and updating all roles.</summary>
        public const string ManageAllRolesPolicy = "Manage All Roles";

        /// <summary>Policy to allow assigning roles the user has access to (Requires new and current roles as parameter).</summary>
        public const string AssignAllowedRolesPolicy = "Assign Allowed Roles";

        ///<summary>Policy to allow viewing all categories records.</summary>
        public const string ViewAllCategoriesPolicy = "View All Categories";

        ///<summary>Policy to allow adding, removing and updating all category records.</summary>
        public const string ManageAllCategoriesPolicy = "Manage All Categories";

        ///<summary>Policy to allow adding, removing and updating all category columns.</summary>
        public const string ViewAllColumnsPolicy = "View All Columns";

        ///<summary>Policy to allow viewing all categories records.</summary>
        public const string ViewAllSubCategoriesPolicy = "View All SubCategories";

        ///<summary>Policy to allow adding, removing and updating all category records.</summary>
        public const string ManageAllSubCategoriesPolicy = "Manage All SubCategories";

        ///<summary>Policy to allow viewing all countries records.</summary>
        public const string ViewAllCountriesPolicy = "View All Countries";

        ///<summary>Policy to allow adding, removing and updating all country records.</summary>
        public const string ManageAllCountriesPolicy = "Manage All Countries";
        
        ///<summary>Policy to allow viewing all cities records.</summary>
        public const string ViewAllCitiesPolicy = "View All Cities";

        ///<summary>Policy to allow adding, removing and updating all city records.</summary>
        public const string ManageAllCitiesPolicy = "Manage All Cities";

        ///<summary>Policy to allow viewing all areas records.</summary>
        public const string ViewAllAreasPolicy = "View All Areas";

        ///<summary>Policy to allow adding, removing and updating all area records.</summary>
        public const string ManageAllAreasPolicy = "Manage All Areas";

        ///<summary>Policy to allow viewing all vendors records.</summary>
        public const string ViewAllVendorsPolicy = "View All Vendors";

        ///<summary>Policy to allow adding, removing and updating all vendor records.</summary>
        public const string ManageAllVendorsPolicy = "Manage All Vendors";

        ///<summary>Policy to allow viewing all offers records.</summary>
        public const string ViewAllOffersPolicy = "View All Offers";

        ///<summary>Policy to allow adding, removing and updating all offer records.</summary>
        public const string ManageAllOffersPolicy = "Manage All Offers";

        ///<summary>Policy to view dashboard.</summary>
        public const string ViewDashboardPolicy = "View Dashboard";

    }



    /// <summary>
    /// Operation Policy to allow adding, viewing, updating and deleting general or specific user records.
    /// </summary>
    public static class AccountManagementOperations
    {
        public const string CreateOperationName = "Create";
        public const string ReadOperationName = "Read";
        public const string UpdateOperationName = "Update";
        public const string DeleteOperationName = "Delete";

        public static UserAccountAuthorizationRequirement Create = new UserAccountAuthorizationRequirement(CreateOperationName);
        public static UserAccountAuthorizationRequirement Read = new UserAccountAuthorizationRequirement(ReadOperationName);
        public static UserAccountAuthorizationRequirement Update = new UserAccountAuthorizationRequirement(UpdateOperationName);
        public static UserAccountAuthorizationRequirement Delete = new UserAccountAuthorizationRequirement(DeleteOperationName);
    }
}
